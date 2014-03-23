using UnityEngine;
using System.Collections;

public class ChangeColorOnGrab : MonoBehaviour, Grabbable{
	
	public Renderer targetMesh;
	private ColorManager colorManager;
	private ColorChanger colorChanger;
	private Color grabbedColor;
	private Color mouseOverColor;
	private MouseOverTarget mouseOverTarget;
	
	// Use this for initialization
	void Start () {
		mouseOverTarget = gameObject.GetComponent<MouseOverTarget>();
		colorManager = GameObject.Find ("ColorManager").GetComponent<ColorManager>();
		grabbedColor = colorManager.grabbedColor;
		mouseOverColor = colorManager.mouseOverColor;
		if(gameObject.GetComponent<ColorChanger>() == null) {
			gameObject.AddComponent<ColorChanger>();
		}
		colorChanger = gameObject.GetComponent<ColorChanger>();
		colorChanger.targetMesh = targetMesh;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void onGrabEnter() {

	}	


	public void onGrab() {
		colorChanger.setColor(grabbedColor);
	}	

	public void onGrabExit() {
		Color colorToSet = mouseOverTarget.targetIsMousedOver() ? mouseOverColor : colorChanger.defaultColor;
		colorChanger.setColor(colorToSet);
	}
}
