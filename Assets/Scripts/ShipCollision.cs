using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipCollision : MonoBehaviour {

	private AudioSource source;

	void Start () {
		AudioSource[] sources = GetComponents<AudioSource> ();
		source = sources [1];
	}

	void OnCollisionEnter (Collision collision)
	{
		source.volume = 1.0f;
		source.Play();
		PlayerStats stats = PlayerStats.getInstance();
		stats.decHp(10);
		stats.updateHpText();
	}

}