using UnityEngine;
using System.Collections;

public class StreakMode : MonoBehaviour, GameMode {


	private int currentStreak = 0;
	private string statusMessage;

	// Use this for initialization
	void Start () {
		statusMessage = "test";
		PostGuesser.OnPostGuess += onPostGuess;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onPostGuess(bool isCorrect) {
		if(isCorrect) {
			currentStreak ++;
		} else {
			currentStreak = 0;
		}
	}

	public void onIncorrectPostGuess() {
		currentStreak = 0;
	}
	
	public void onGameModeActive() {
		GUI.Label(new Rect(5, 5, 100, 50), currentStreak.ToString());
	}
}
