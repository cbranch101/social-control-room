using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PostGuesser : MonoBehaviour {

	public Dictionary<string,PostTest> allPosts = new Dictionary<string,PostTest>();
	private GUITest gui;


	// Use this for initialization
	void Start () {
		setPosts ();
		gui = GameObject.Find ("GUI").GetComponent<GUITest>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void guess(string postName) {
		PostTest guessedPost = allPosts[postName];
		if(guessedPost.isCorrect) {
			gui.statusMessage = "correct!";
		} else {
			gui.statusMessage = "WRRRROOOONGGG!";
		}
	} 

	void setPosts() {
		// iterate over all of the children and set their components. 
		foreach(Transform child in gameObject.transform) {
			PostTest post = child.gameObject.GetComponent<PostTest>();
			if(post != null) {
				allPosts[post.name] = post;
			}
		}
	}
}
