using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
	private Text countdownText;
	public GameObject endGameCanvas;

	public void initGameOverCanvas(int score){
		GameObject scoreTextObject = endGameCanvas.transform.GetChild (1).gameObject;
		Text scoreText = scoreTextObject.GetComponent<Text> ();
		scoreText.text = scoreText.text + " " + score;
		GameObject countdownTextObject = endGameCanvas.transform.GetChild (2).gameObject;
		countdownText = countdownTextObject.GetComponent<Text> ();
		endGameCanvas.SetActive(true);
		StartCoroutine (waitForRestart ());
	}

	private IEnumerator waitForRestart() 
	{
		Time.timeScale = 0.0001f;
		float pauseEndTime = Time.realtimeSinceStartup + 5; 

		float number5 = Time.realtimeSinceStartup + 1;
		float number4 = Time.realtimeSinceStartup + 2;
		float number3 = Time.realtimeSinceStartup + 3;
		float number2 = Time.realtimeSinceStartup + 4;
		float number1 = Time.realtimeSinceStartup + 5; 

		while (Time.realtimeSinceStartup < pauseEndTime) 
		{
			if(Time.realtimeSinceStartup <= number5)      
				countdownText.text = "Back in Time in ... 5";
			else if(Time.realtimeSinceStartup <= number4) 
				countdownText.text = "Back in Time in ... 4";
			else if(Time.realtimeSinceStartup <= number3) 
				countdownText.text = "Back in Time in ... 3";
			else if(Time.realtimeSinceStartup <= number2) 
				countdownText.text = "Back in Time in ... 2";
			else if(Time.realtimeSinceStartup <= number1) 
				countdownText.text = "Back in Time in ... 1";
			yield return null;
		}
		Time.timeScale = 1.0f;
		SceneManager.LoadScene (0);
	}
}

