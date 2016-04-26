using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {
	void Start() {
		PlayerStats stats = PlayerStats.getInstance();
		stats.updateHpText();
		stats.updateScoreText();
	}
}