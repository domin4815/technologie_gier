using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpCreatorWithinSphere : MonoBehaviour {

	public List<GameObject> prefabs;
	public GameObject reference;
	public int numberOfObjects;
	public float minStartDistFromShip;
	public float maxStartDistFromShip;
	public float destroyDistFromShip;
	public float delay = 2.0f;
	private GameObject prefab;
	private float objectRadius;
	private float currentDelay = 0f;

	public void CreateObject() {
		int index = Random.Range (0, prefabs.Count);
		prefab = prefabs [index];
		bool isCreated = false;
		while (!isCreated) {
			float distance = Random.Range(minStartDistFromShip * 1.0f, maxStartDistFromShip * 1.0f);
			Vector3 pos = new Vector3 (Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
			pos = pos.normalized * distance;
			pos = reference.transform.position + pos;
			Collider[] hitColliders = Physics.OverlapSphere (pos, objectRadius);
			if (hitColliders.Length == 0) {
				GameObject obj = Instantiate (prefab, pos, Quaternion.identity) as GameObject;
				obj.transform.parent = transform;
				isCreated = true;
			}
		}
	}

	void Start() {
		SphereCollider collider = prefabs[0].transform.GetChild(2).GetComponent<SphereCollider> ();
		objectRadius = collider.radius * prefabs[0].transform.localScale.x;
		for (int i = 0; i < numberOfObjects; i++) {
			CreateObject();
		}
	}
		
	void Update () {
		if(Time.time > currentDelay) {
			foreach (Transform t in transform) {
				float distanceFromShip = Vector3.Distance (t.position, reference.transform.position);
				if (distanceFromShip > destroyDistFromShip) {
					Destroy (t.gameObject);
					CreateObject();
				}
			}
			currentDelay = Time.time + delay;
		}
	}
}
