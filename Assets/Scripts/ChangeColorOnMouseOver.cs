using UnityEngine;
using System.Collections;

public class ChangeColorOnMouseOver : MonoBehaviour, MouseOverable {


	private ColorChanger colorChanger;
	public Color mouseOverColor;
	public Color normalColor;

	// Use this for initialization
	void Start () {
		colorChanger = gameObject.GetComponent<ColorChanger>();
		colorChanger.setColor(normalColor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onMouseOverEnter() {
		colorChanger.setColor (mouseOverColor);
	}

	public void onMouseOverExit() {
		colorChanger.setColor (normalColor);
	}
}
