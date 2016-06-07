using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSound : MonoBehaviour
{

	private GameObject player;
	public float maxDistance;
	private bool canPlayAudio = true;
	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource>();
		player = GameObject.FindWithTag("Player");
	}

	void Update () {
		var playerDistance = Vector3.Distance(player.transform.position, transform.position);
		if (playerDistance < maxDistance + 100.0f) {
			int clips = player.GetComponent<ShipCollision> ().maxClips;
			if (canPlayAudio && clips < 1) {
				source.loop = true;
				float distance = (float) (maxDistance - playerDistance + 100.0f) / maxDistance;
				if(distance>0)
					source.volume = distance;
				source.Play();
				canPlayAudio = false;
				player.GetComponent<ShipCollision> ().maxClips += 1;
			} else {
				source.volume = (float) (maxDistance - playerDistance + 100.0f) / maxDistance;
			}
		} else {
			if(!canPlayAudio){
				source.Stop();
				canPlayAudio = true;
				player.GetComponent<ShipCollision> ().maxClips -= 1;
			}
		}
	}

}

