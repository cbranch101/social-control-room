using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameModeHandler : MonoBehaviour {

	
	Dictionary<string, GameMode> gameModeKey = new Dictionary<string, GameMode>();
	public GameMode currentGameMode = null;
	// Use this for initialization
	void Start () {
		GameMode streakMode = gameObject.GetComponent(typeof(StreakMode)) as GameMode;
		gameModeKey["1"] = streakMode;
		currentGameMode = streakMode;
	}
	
	// Update is called once per frame
	void Update () {
		handleKeyPress();
	}

	void handleKeyPress() {
		if(Input.anyKeyDown) {
			if(gameModeKey.ContainsKey(Input.inputString)) {
				GameMode gameMode = gameModeKey[Input.inputString];
				currentGameMode = gameMode;
			}
		}
	}
}

public interface GameMode {
	void onGameModeActive();
}
