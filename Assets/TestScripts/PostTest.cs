using UnityEngine;
using System.Collections;

public class PostTest : MonoBehaviour {

	public string name;
	public string text;
	public Texture image;
	public bool isCorrect;


	public void initialize(string newText, Texture newImage, bool  newIsCorrect) {
		text = newText;
		image = newImage;
		isCorrect = newIsCorrect;
		Debug.Log (text);
	}
	
}
