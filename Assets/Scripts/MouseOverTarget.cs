using UnityEngine;
using System.Collections;
using System.Linq;

public class MouseOverTarget : MonoBehaviour {
	
	private bool isMousedOver;

	public delegate void MouseOverAction();
	public event MouseOverAction OnMouseOverEnter;
	public event MouseOverAction OnMouseOverExit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool targetIsMousedOver() {
		return isMousedOver;
	}

	public void triggerOnMouseOverEnter() {
		isMousedOver = true;
		if(OnMouseOverEnter != null) {
			OnMouseOverEnter();
		}
	}
	
	public void triggerOnMouseOverExit() {
		isMousedOver = false;
		if(OnMouseOverExit != null) {
			OnMouseOverExit();
		}
	}

}
