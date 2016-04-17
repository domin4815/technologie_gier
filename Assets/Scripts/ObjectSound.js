private var player : GameObject;
public var maxDistance : float;
private var canPlayAudio = true;
private var source : AudioSource;

function Start () {
	source = GetComponent.<AudioSource>();
	player = GameObject.FindWithTag("Player");
}

function Update () {
	var playerDistance = Vector3.Distance(player.transform.position, transform.position);
 	if (playerDistance < maxDistance) {
 		if (canPlayAudio) {
 			source.loop = true;
 			source.volume = (maxDistance - playerDistance) / maxDistance;
 			source.Play();
 			canPlayAudio = false;
 		} else {
 			source.volume = (maxDistance - playerDistance) / maxDistance;
 		}
 	} else {
 		if(!canPlayAudio){
 			source.Stop();
 			canPlayAudio = true;
 		}
 	}
}

