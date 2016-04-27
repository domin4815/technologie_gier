using UnityEngine;
using System.Collections;

public class InitShipUI : MonoBehaviour {
	void Start() {
		PlayerStats stats = PlayerStats.getInstance();
		stats.updateHpText();
		stats.updateScoreText();
	}
}