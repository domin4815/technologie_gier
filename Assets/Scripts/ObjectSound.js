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
 	if (playerDistance < maxDistance + 200.0) {
 		if (canPlayAudio) {
 			source.loop = true;
 			var distance = (maxDistance - playerDistance + 200.0) / maxDistance;
 			if(distance>0)
 				source.volume = distance;
 			source.Play();
 			canPlayAudio = false;
 		} else {
 			source.volume = (maxDistance - playerDistance + 200.0) / maxDistance;
 		}
 	} else {
 		if(!canPlayAudio){
 			source.Stop();
 			canPlayAudio = true;
 		}
 	}
}

