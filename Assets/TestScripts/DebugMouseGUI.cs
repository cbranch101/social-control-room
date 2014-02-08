using UnityEngine;
using System.Collections;

public class DebugMouseGUI : MonoBehaviour {

	public Texture mouseIndicator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		GUILayout.BeginArea (new Rect(0, 0, 100, 100));
			GUILayout.Box (webImage);
		Debug.Log("test");

	}
}
