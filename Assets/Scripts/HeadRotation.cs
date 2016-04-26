using UnityEngine;

public class HeadRotation : MonoBehaviour {
	public bool updateEarly = false;

	public delegate void HeadUpdatedDelegate(GameObject head);
	public TextMesh tm;
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

		transform.localRotation = Cardboard.SDK.HeadPose.Orientation;

		if (OnHeadUpdated != null) {
			OnHeadUpdated(gameObject);
		}
	}
}
