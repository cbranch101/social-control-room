using UnityEngine;
using System.Collections;
using SimpleJSON;

public class WWWTest : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {

		string url = "http://dev.fbdev.me/apps/clay/social_control_api/test.php";
		WWW queryHandler = new WWW(url);
		yield return queryHandler;
		JSONNode testData = JSON.Parse (queryHandler.text);
		string test = testData["message"]["formatted_value"];
		Debug.Log (test);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
