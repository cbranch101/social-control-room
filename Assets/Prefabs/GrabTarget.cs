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
			if(!isGrabbed && willBeGrabbed) {
				triggerOnGrabEnter();
			}

			if(isGrabbed && !willBeGrabbed) {
				triggerOnGrabExit();
			}

			isGrabbed = willBeGrabbed;
		}
	}

	public delegate void GrabAction();
	public event GrabAction OnGrab;
	public event GrabAction OnGrabEnter;
	public event GrabAction OnGrabExit;
	
	public MouseOverTarget mouseOverTarget;
	// Use this for initialization
	// Update is called once per frame
	void Update () {

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
		if(OnGrab != null) {
			OnGrab();
		}
	}

	void triggerOnGrabEnter() {
		if(OnGrabEnter != null) {
			OnGrabEnter();
		}
	}


	void triggerOnGrabExit() {
		if(OnGrabExit != null) {
			OnGrabExit();
		}
	}

	public bool targetIsGrabbed() {
		return isGrabbed;
	}
	

}