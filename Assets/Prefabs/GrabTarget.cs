using UnityEngine;
using System.Collections;
using System.Linq;

public class GrabTarget : MonoBehaviour {

	private bool isGrabbed;
	public bool IsGrabbed {
		get {
			return isGrabbed;
		}
		set{
			bool willBeGrabbed = value;
			if(isGrabbed && !willBeGrabbed) {
				triggerOnGrabExit();
			}

			isGrabbed = willBeGrabbed;
		}
	}

	private Grabbable[] grabbables;
	MouseOverTarget mouseOverTarget;
	// Use this for initialization
	void Start () {
		mouseOverTarget = gameObject.GetComponent<MouseOverTarget>();
		grabbables = gameObject.GetInterfaces<Grabbable>();
	}
	
	// Update is called once per frame
	void Update () {
		bool mouseIsDown = Input.GetMouseButton(0);
		bool isMousedOver = mouseOverTarget.targetIsMousedOver();
		if(!IsGrabbed) {
			IsGrabbed = mouseOverTarget.targetIsMousedOver() ? Input.GetMouseButton(0) : false;
		} else {
			IsGrabbed = Input.GetMouseButton(0);
		}

		if(IsGrabbed) {
			triggerGrabbed();
		}
	}

	void triggerGrabbed() {
		foreach(Grabbable grabbable in grabbables) {
			grabbable.onGrab();
		}
	}

	void triggerOnGrabExit() {
		foreach(Grabbable grabbable in grabbables) {
			grabbable.onGrabExit();
		}

	}

	public bool targetIsGrabbed() {
		return isGrabbed;
	}
	

}

public interface Grabbable {
	
	void onGrabExit();
	void onGrab();

}
