using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {

	private Texture webImage;
	public int messageBoxWidth;
	public int spaceBetweenBoxes;
	public string statusMessage;
	public int rightImpressions = 100;
	public int leftImpressions = 200;

	// Use this for initialization
	void Start () {
	
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
						GUILayout.Label ("Did you miss the premiere of the Bonnie & Clyde Movie Event? Fear not, catch the Barrow Gang online for free! Part 1: http://aetv.us/IB2U9X Part 2: http://aetv.us/1jIwvg4");
							GUILayout.Box (webImage);
						
							if(GUILayout.Button ("Pick Me", GUILayout.Height (75))) {
								statusMessage = leftImpressions > rightImpressions ? "Correct" : "Incorrect";
							}
					GUILayout.EndVertical();
				GUILayout.EndArea();
				GUILayout.BeginArea (new Rect (messageBoxWidth + spaceBetweenBoxes,  0, messageBoxWidth, messageBoxWidth));
					GUILayout.BeginVertical();
						GUILayout.Label ("Did you miss the premiere of the Bonnie & Clyde Movie Event? Fear not, catch the Barrow Gang online for free! Part 1: http://aetv.us/IB2U9X Part 2: http://aetv.us/1jIwvg4");
						GUILayout.Box (webImage);
						if(GUILayout.Button ("Pick Me", GUILayout.Height (75))) {
							statusMessage = rightImpressions > leftImpressions ? "Correct" : "Incorrect";
							
						}
					GUILayout.EndVertical();
				GUILayout.EndArea();
			GUILayout.EndHorizontal();
		GUILayout.EndArea ();
	}

}
