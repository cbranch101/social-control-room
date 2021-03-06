﻿using UnityEngine;
using System.Collections;
using SimpleJSON;

public class PostDataHandler : MonoBehaviour {

	public string postDataURL = "none";
	private Hashtable postData = new Hashtable();
	public delegate void PostDataAction(Hashtable postData);
	public delegate void UpdateStartAction();

	public static event PostDataAction OnPostDataReceived;
	public static event UpdateStartAction OnPostDataUpdateEnter;

	// Use this for initialization
	void Start () {
		startPostUpdate();
	}

	public void startPostUpdate() {
		StartCoroutine("updatePostData");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator updatePostData () {

		WWW queryHandler = new WWW(postDataURL);
		yield return queryHandler;
		JSONNode jsonResponse = JSON.Parse (queryHandler.text);
		convertJsonResponseToPostData(jsonResponse);
		if(OnPostDataReceived != null) {
			StartCoroutine(triggerPostDataReceived(postData));
		}
	}

	IEnumerator triggerPostDataReceived(Hashtable postData) {
		if(OnPostDataUpdateEnter != null) {
			OnPostDataUpdateEnter();
		}

		bool allPostsLoaded = true;
		foreach(string postName in postData.Keys) {
			Hashtable post = (Hashtable)postData[postName];
			bool currentPostIsLoaded = (bool)post["is_loaded"];
			if(allPostsLoaded && !currentPostIsLoaded) {
				allPostsLoaded = false;
			}
		}

		if(!allPostsLoaded) {
			yield return new WaitForSeconds(0.1f);
			StartCoroutine(triggerPostDataReceived(postData));
		} else {
			OnPostDataReceived(postData);
			yield break;
		}

	}

	void convertJsonResponseToPostData(JSONNode jsonResponse) {
		JSONNode jsonPosts = jsonResponse["posts"];
		foreach(JSONNode jsonPost in jsonPosts.Childs ) {
			Hashtable post = new Hashtable();
			string name = jsonPost["name"];
			string imageURL = jsonPost["image_url"];
			string message = jsonPost["message"];
			bool isCorrect = jsonPost["is_correct"].AsBool;
			post["image_url"] = imageURL;
			post["message"] = message;
			post["is_correct"] = isCorrect;
			post["is_loaded"] = false;
			postData[name] = post;
			StartCoroutine(setImageForPost(post, name));
		}
	}

	IEnumerator setImageForPost(Hashtable post, string postName) {
		string imageURL = (string)post["image_url"];
		WWW queryHandler = new WWW(imageURL);
		yield return queryHandler;
		Texture postImage = queryHandler.texture;
		post["image"] = postImage;
		post["is_loaded"] = true;
		postData[postName] = post;
	}

}
