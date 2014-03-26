using UnityEngine;
using System.Collections;

public class PostDataImage : MonoBehaviour {
	
	public Texture loadingTexture;
	public string postName = "none";
	public string imageKey = "none";
	// Use this for initialization
	void Start () {
		PostDataHandler.OnPostDataReceived += updateImage;
		PostDataHandler.OnPostDataUpdateEnter += onPostDataUpdateEnter;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void setTexture(Texture textureToSet) {
		gameObject.renderer.materials[0].mainTexture = textureToSet;
	}

	void onPostDataUpdateEnter() {
		setTexture (loadingTexture);
	}

	void updateImage(Hashtable postData) {
		Hashtable post = (Hashtable)postData[postName];
		Texture postTexture = (Texture)post[imageKey];
		setTexture(postTexture);

	}


}
