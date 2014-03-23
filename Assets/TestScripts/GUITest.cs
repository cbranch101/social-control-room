using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {

	private Texture webImage;
	public int messageBoxWidth;
	public int spaceBetweenBoxes;
	public string statusMessage;
	public PostTest leftPost;
	public PostTest rightPost;
	private PostGuesser postGuesser;

	// Use this for initialization
	void Start () {
//		postGuesser = GameObject.Find ("Posts").GetComponent<PostGuesser>();

	}

	public void setWebImage(Texture image) {
		webImage = image;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() {
		centeredGuiLayoutTest();
	}

	void imageTest() {
		if(webImage != null) {
			GUI.DrawTexture(new Rect(0, 0, webImage.height, webImage.width), webImage);
		}

	}

	void simpleGuiLayoutTest() {
		GUILayout.Button ("Test Button");
		GUILayout.Box (webImage);
	}

	void centeredGuiLayoutTest() {
		int mainAreaSize = (messageBoxWidth * 2) + spaceBetweenBoxes;
		int horizontalCenter = (Screen.width / 2) - (mainAreaSize / 2);
		int verticalCenter = (Screen.height / 2) - messageBoxWidth;
		GUI.Label (new Rect(0, 0, 100, 50), statusMessage);
		GUILayout.BeginArea (new Rect(horizontalCenter, verticalCenter, mainAreaSize, messageBoxWidth));
			GUILayout.BeginHorizontal();
				GUILayout.BeginArea (new Rect (0, 0, messageBoxWidth, messageBoxWidth));
					GUILayout.BeginVertical();
						GUILayout.Label (leftPost.text);
							GUILayout.Box (leftPost.image);
						
							if(GUILayout.Button ("Pick Me", GUILayout.Height (75))) {
//								postGuesser.guess ("left");							
							}
					GUILayout.EndVertical();
				GUILayout.EndArea();
				GUILayout.BeginArea (new Rect (messageBoxWidth + spaceBetweenBoxes,  0, messageBoxWidth, messageBoxWidth));
					GUILayout.BeginVertical();
						GUILayout.Label (rightPost.text);
						GUILayout.Box (rightPost.image);
						if(GUILayout.Button ("Pick Me", GUILayout.Height (75))) {
//							postGuesser.guess ("right");		
						}
					GUILayout.EndVertical();
				GUILayout.EndArea();
			GUILayout.EndHorizontal();
		GUILayout.EndArea ();
	}

}
