using UnityEngine;
using System.Collections;

public class PlayerStats {

	private int hp;
	private int score;
	public int maxHp = 100;

	private static PlayerStats instance = null;
	

	private PlayerStats() {
		hp = 50;
		score = 0;
	}


	public static PlayerStats getInstance() {
		if(instance == null) {
			instance = new PlayerStats();
		}
		return instance;
	}

	public void addHp(int h) {
		hp += h;
		if(hp > maxHp)
			hp = maxHp;
	}

	public void decHp(int h) {
		hp -= h;
		if (hp < 0)
			hp = 0;
	}

	public string getHpString() {
		return hp + " HP";
	} 

	public void addScore(int s) {
		score += s;
	}

	public string getScoreString() {
		return score + " points";
	}

	public void Start () {
		instance = new PlayerStats();
	}

	public void updateHpText() {
		TextMesh text = (TextMesh) GameObject.Find("TextHP").GetComponent("TextMesh");
		text.text = this.getHpString();
	}

	public void updateScoreText() {
		TextMesh text = (TextMesh) GameObject.Find("TextPoints").GetComponent("TextMesh");
		text.text = this.getScoreString();
	}
}