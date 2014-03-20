using UnityEngine;
using System.Collections;

public class PostDataImage : MonoBehaviour {

	public string postName = "none";
	public string imageKey = "none";
	// Use this for initialization
	void Start () {
		PostDataHandler.OnPostDataReceived += updateImage;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void updateImage(Hashtable postData) {
		Hashtable post = (Hashtable)postData[postName];
		Texture postTexture = (Texture)post[imageKey];
		gameObject.renderer.materials[0].mainTexture = postTexture;
	}


}
