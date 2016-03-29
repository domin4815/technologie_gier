using UnityEngine;
using System.Collections;

public class AsteroidPropeller : MonoBehaviour {

	public float thrust;
	public float maxRotationSpeed;
	private Rigidbody rigidbody;
	private Vector3 direction;
	private float rotationX;
	private float rotationY;
	private float rotationZ;

	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		Vector3 vector = new Vector3 (Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
		direction = vector.normalized;
		rotationX = maxRotationSpeed * Random.value;
		rotationY = maxRotationSpeed * Random.value;
		rotationZ = maxRotationSpeed * Random.value;
	}

	void FixedUpdate () {
		rigidbody.AddForce (direction * thrust);
	}

	void Update() {
		transform.Rotate (Time.deltaTime * rotationX, Time.deltaTime * rotationY, Time.deltaTime * rotationZ);
	}
}
