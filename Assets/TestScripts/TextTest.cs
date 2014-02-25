using UnityEngine;
using System.Collections;

public class TextTest : MonoBehaviour {

	CCText textMesh;
	// Use this for initialization
	void Start () {
		textMesh = GetComponent<CCText>();
		textMesh.Text = "Did you miss the premiere of the Bonnie & Clyde Movie Event? Fear not, catch the Barrow Gang online for free! \r\n\r\nPart 1: http://aetv.us/IB2U9X\r\nPart 2: http://aetv.us/1jIwvg4";
	}
	
	// Update is called once per frame
	void Update () {

	}
}
