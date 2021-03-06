﻿using UnityEngine;
using System.Collections;

public class PostGuesser : MonoBehaviour {

	public ClickButtonOnGrab targetButton;
	private PostDataHandler postDataHandler;
	public LockingMechanism targetMechanism;
	private Hashtable postData;
	private string selectedPost = null;
	public Light rightLight;
	public Light leftLight;
	public delegate void GuessAction(bool isCorrect);
	public static event GuessAction OnPostGuess;
	// Use this for initialization
	void Start () {
		postDataHandler = GameObject.Find ("PostDataHandler").GetComponent<PostDataHandler>();
		rightLight.enabled = false;
		leftLight.enabled = false;
		PostDataHandler.OnPostDataReceived += updatePostData;
		targetButton.OnClick += respondToButtonClick;
		targetMechanism.OnLockEnter += selectPost;
		targetMechanism.OnLockExit += deselectPost;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void updatePostData(Hashtable updatedPostData) {
		postData = updatedPostData;
	}

	void selectPost(bool isRight) {
		selectedPost = isRight ? "right" : "left";
	}

	void respondToButtonClick() {
		if(selectedPost != null) {
			Hashtable associatedPost = (Hashtable) postData[selectedPost];
			bool isCorrect = (bool) associatedPost["is_correct"];
			if(isCorrect) {
				Light lightToTurnOn = selectedPost == "right" ? rightLight : leftLight;
				lightToTurnOn.enabled = true;
			} else {

			}
			triggerOnGuess(isCorrect);
		}
	}

	void triggerOnGuess(bool isCorrect) {
		postDataHandler.startPostUpdate();
		if(OnPostGuess != null) {
			OnPostGuess(isCorrect);
		}
	}

	void deselectPost(bool isRight) {
		selectedPost = null;
		updateLights (isRight, false);
	}


	void updateLights(bool updateRight, bool lightShouldBeOn) {
		Light selectedLight = updateRight ? rightLight : leftLight;
		selectedLight.enabled = lightShouldBeOn;
	}

}
