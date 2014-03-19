using UnityEngine;
using System.Collections;

public class ChangeColorOnMouseOver : MonoBehaviour, MouseOverable {
	
	public Renderer targetMesh;
	private ColorManager colorManager;
	private ColorChanger colorChanger;
	private Color mousedOverColor;

	// Use this for initialization
	void Start () {
		colorManager = GameObject.Find ("ColorManager").GetComponent<ColorManager>();
		mousedOverColor = colorManager.mouseOverColor;
		if(gameObject.GetComponent<ColorChanger>() == null) {
			gameObject.AddComponent<ColorChanger>();
		}
		colorChanger = gameObject.GetComponent<ColorChanger>();
		colorChanger.targetMesh = targetMesh;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onMouseOverEnter() {
		colorChanger.setColor(mousedOverColor);
	}

	public void onMouseOverExit() {
		colorChanger.setColor(colorChanger.defaultColor);
	}

}
