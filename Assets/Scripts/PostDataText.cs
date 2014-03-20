using UnityEngine;
using System.Collections;

public class PostDataText : MonoBehaviour {
	
	public string postName = "none";
	public string textKey = "none";
	private CCText textMesh;
	// Use this for initialization
	void Start () {
		PostDataHandler.OnPostDataReceived += updateText;
		textMesh = GetComponent<CCText>();

	}
	
	void updateText(Hashtable postData) {
		Hashtable post = (Hashtable)postData[postName];
		string postText = (string)post[textKey];
		textMesh.Text = postText;
	}
	
	
}

