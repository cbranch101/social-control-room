using UnityEngine;
using System.Collections;
using SimpleJSON;

public class QueryTest : MonoBehaviour {


	private Texture testImage;
	public GUITest gui;
	private PostGuesser postGuesser;


	// Use this for initialization
	IEnumerator Start () {
		GameObject postGuesserObject = GameObject.Find ("Posts");
		postGuesser = postGuesserObject.GetComponent<PostGuesser>();
		string url = "http://dev.fbdev.me/apps/clay/social_control_api/posts.php";
		WWW queryHandler = new WWW(url);
		yield return queryHandler;
		JSONNode testData = JSON.Parse (queryHandler.text);
		JSONNode posts = testData["posts"];
//		string imageURL = testData["message"]["data"]["post_picture_url"];
//		WWW imageHandler = new WWW(imageURL);
//		yield return imageHandler;
//		gui.setWebImage(imageHandler.texture);

	}

	void handlePosts(JSONNode posts) {
		foreach(JSONNode post in posts.Childs) {
			Debug.Log (post["message"]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
