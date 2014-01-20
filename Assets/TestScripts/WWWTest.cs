using UnityEngine;
using System.Collections;

public class WWWTest : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {

		string url = "http://dev.fbdev.me/apps/clay/social_control_api/test.php";
		WWW queryHandler = new WWW(url);
		yield return queryHandler;
		Debug.Log (queryHandler.text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
