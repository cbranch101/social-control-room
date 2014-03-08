using UnityEngine;
using System.Collections;

public class MouseBehavior : MonoBehaviour {

	private MouseOverTarget previousMouseOverTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		detectMouseOver();
	}

	void detectMouseOver() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast (ray, out hit, 1000f)) {
			MouseOverTarget mouseOverTarget = hit.collider.gameObject.GetComponent<MouseOverTarget>();
			previousMouseOverTarget = mouseOverTarget;
			if(mouseOverTarget != null) {
				mouseOverTarget.isMousedOver = true;
			}
		} else {
			if(previousMouseOverTarget != null) {
				previousMouseOverTarget.isMousedOver = false;
				previousMouseOverTarget = null;
			}
		}


	}
}
