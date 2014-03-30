using UnityEngine;
using System.Collections;

public class GUIHandler : MonoBehaviour {

	public static string logMessage = "none";
	private GameModeHandler gameModeHandler;
	// Use this for initialization
	void Start () {
		gameModeHandler = GameObject.Find ("GameModeHandler").GetComponent<GameModeHandler>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		drawGameModeHUD();
//		GUI.Label(new Rect(200, 5, 100, 50), GUIHandler.logMessage);
	}

	void drawGameModeHUD() {
		if(gameModeHandler.currentGameMode != null) {
			gameModeHandler.currentGameMode.onGameModeActive();
		}
	}

}
