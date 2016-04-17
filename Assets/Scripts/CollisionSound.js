#pragma strict

private var source : AudioSource; 

function Start () {
	var sources = GetComponents(AudioSource); 
	source = sources[1];
}

function OnCollisionEnter (col : Collision)
{
	source.volume = 1.0;
	source.Play();
}