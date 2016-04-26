using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TakeAblePowerUp : MonoBehaviour
{
	private AudioSource audioSource;
	public TextMesh hpText = null;
	public TextMesh scoreText = null;
	public GameObject spaceShip;
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider collider) {
		if(collider.tag == "Player") {
			AudioSource.PlayClipAtPoint (audioSource.clip, transform.position);
			PerformAction(transform.parent.gameObject);
			Destroy(transform.parent.gameObject);
			GameObject creator = GameObject.FindGameObjectWithTag ("Creator");
			creator.GetComponent<PowerUpCreatorWithinSphere> ().CreateObject ();
		}
	}

	void PerformAction(GameObject obj) {
		PlayerStats stats = PlayerStats.getInstance();
		if(obj.tag == "RedPowerUp") {
			stats.addHp(10);
			stats.updateHpText();
		} else if(obj.tag == "YellowPowerUp") {
			stats.addScore(1);
			stats.updateScoreText();
		}
	}
}

