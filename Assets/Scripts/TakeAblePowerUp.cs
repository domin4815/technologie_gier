using UnityEngine;
using System.Collections;

public class TakeAblePowerUp : MonoBehaviour
{
	private AudioSource audioSource;

	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider collider) {
		if(collider.tag == "Player") {
			AudioSource.PlayClipAtPoint (audioSource.clip, transform.position);
			Destroy(transform.parent.gameObject);
			GameObject creator = GameObject.FindGameObjectWithTag ("Creator");
			creator.GetComponent<PowerUpCreatorWithinSphere> ().CreateObject ();
		}
	}
}

