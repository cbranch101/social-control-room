using UnityEngine;
using System.Collections;

public class ChangeColorOnMouseOver : MonoBehaviour {
	
	public Renderer targetMesh;
	public MouseOverTarget mouseOverTarget;
	private ColorManager colorManager;
	private ColorChanger colorChanger;
	private Color mousedOverColor;
	public GrabTarget grabTarget;

	void Awake() {
		colorManager = GameObject.Find ("ColorManager").GetComponent<ColorManager>();
		mousedOverColor = colorManager.mouseOverColor;
		if(gameObject.GetComponent<ColorChanger>() == null) {
			gameObject.AddComponent<ColorChanger>();
		}
		colorChanger = gameObject.GetComponent<ColorChanger>();
	}

	// Use this for initialization
	void Start () {
		colorChanger.targetMesh = targetMesh;
		mouseOverTarget.OnMouseOverEnter += onMouseOverEnter;
		mouseOverTarget.OnMouseOverExit += onMouseOverExit;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onMouseOverEnter() {
		changeColor(mousedOverColor);
	}

	public void changeColor(Color colorToSet) {

		if(!grabTarget.IsGrabbed) {
			colorChanger.setColor (colorToSet);
		}

	}

	public void onMouseOverExit() {
		changeColor(colorChanger.defaultColor);
	}

}
