using UnityEngine;
using System.Collections;
using SimpleJSON;

public class WWWTest : MonoBehaviour {

	private Texture testImage;

	// Use this for initialization
	IEnumerator Start () {

		string url = "http://dev.fbdev.me/apps/clay/social_control_api/test.php";
		WWW queryHandler = new WWW(url);
		yield return queryHandler;
		JSONNode testData = JSON.Parse (queryHandler.text);
		string imageURL = testData["message"]["data"]["post_picture_url"];
		WWW imageHandler = new WWW(imageURL);
		yield return imageHandler;
		testImage = imageHandler.texture;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		if(testImage != null) {
			GUI.DrawTexture(new Rect(0, 0, testImage.height, testImage.width), testImage);
		}
	}





}
