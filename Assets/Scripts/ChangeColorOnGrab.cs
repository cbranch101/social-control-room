using UnityEngine;
using System.Collections;

public class ChangeColorOnGrab : MonoBehaviour{
	
	public Renderer targetMesh;
	private ColorManager colorManager;
	private ColorChanger colorChanger;
	private Color grabbedColor;
	private Color mouseOverColor;
	public MouseOverTarget mouseOverTarget;
	public GrabTarget grabTarget;
	
	// Use this for initialization

	void Awake() {
		colorManager = GameObject.Find ("ColorManager").GetComponent<ColorManager>();
		grabbedColor = colorManager.grabbedColor;
		mouseOverColor = colorManager.mouseOverColor;
		if(gameObject.GetComponent<ColorChanger>() == null) {
			gameObject.AddComponent<ColorChanger>();
		}
		colorChanger = gameObject.GetComponent<ColorChanger>();
	}

	void Start () {
		colorChanger.targetMesh = targetMesh;
		grabTarget.OnGrab += onGrab;
		grabTarget.OnGrabExit += onGrabExit;
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
