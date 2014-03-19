using UnityEngine;
using System.Collections;
using System.Linq;

public class MouseOverTarget : MonoBehaviour {
	
	private bool isMousedOver;
	private MouseOverable[] mouseOverables;

	// Use this for initialization
	void Start () {
		mouseOverables = gameObject.GetInterfaces<MouseOverable>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool targetIsMousedOver() {
		return isMousedOver;
	}

	public void triggerOnMouseOverEnter() {
		isMousedOver = true;
		foreach(MouseOverable mouseOverable in mouseOverables) {
			if(mouseOverable != null) {
				mouseOverable.onMouseOverEnter();
			}
		}

	}
	
	public void triggerOnMouseOverExit() {
		isMousedOver = false;
		foreach(MouseOverable mouseOverable in mouseOverables) {
			if(mouseOverable != null) {
				mouseOverable.onMouseOverExit();
			}
		}
	}

}

public interface MouseOverable {

	void onMouseOverEnter();

	void onMouseOverExit();

}
