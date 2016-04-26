using UnityEngine;

public class CustomCardboardHead : MonoBehaviour {
	public bool trackRotation = true;
	public bool trackPosition = true;
	public Transform target;
	public bool updateEarly = false;
	public float thrust = 0.5f;

	public Ray Gaze {
		get {
			UpdateHead();
			return new Ray(transform.position, transform.forward);
		}
	}

	public delegate void HeadUpdatedDelegate(GameObject head);

	public event HeadUpdatedDelegate OnHeadUpdated;

	void Awake() {
		Cardboard.Create();
	}

	private bool updated;

	void Update() {
		updated = false;
		if (updateEarly) {
			UpdateHead();
		}
	}

	void LateUpdate() {
		UpdateHead();
	}

	private void UpdateHead() {
		if (updated) {
			return;
		}
		updated = true;
		Cardboard.SDK.UpdateState();

		if (trackRotation) {
			var rot = Cardboard.SDK.HeadPose.Orientation;
			if (target == null) {
				transform.localRotation = rot;
			} else {
				transform.rotation = target.rotation * rot;
			}
		}

		if (trackPosition) {
			Vector3 pos = Cardboard.SDK.HeadPose.Position;
			if (target == null) {
				transform.localPosition = pos+transform.localPosition;
				transform.position = transform.position+transform.forward*thrust;
			} else {
				transform.position = target.position + target.rotation * pos;
			}
		}

		if (OnHeadUpdated != null) {
			OnHeadUpdated(gameObject);
		}
	}
}
