using UnityEngine;
using System.Collections;

public class DetectMouseOver : MonoBehaviour {


	private MouseOverTarget currentMouseOverTarget;
	public MouseOverTarget CurrentTarget {
		set {
			MouseOverTarget newMouseOverTarget = value;
			bool isEnteringMouseOver = currentMouseOverTarget == null && newMouseOverTarget != null;
			bool newTargetIsSame = targetsAreSame(currentMouseOverTarget, newMouseOverTarget);
			bool isExitingMouseOver = (newMouseOverTarget == null || !newTargetIsSame) && currentMouseOverTarget != null;

			if(isEnteringMouseOver) {
				newMouseOverTarget.triggerOnMouseOverEnter();
				currentMouseOverTarget = newMouseOverTarget;
			} else {
				if(isExitingMouseOver) {
					currentMouseOverTarget.triggerOnMouseOverExit();
					currentMouseOverTarget = null;
				}
			}
		}

	}


	// Use this for initialization
	void Start () {
	
	}

	bool targetsAreSame(MouseOverTarget target1, MouseOverTarget target2) {
		bool areSame = false;
		if(target1 != null && target2 != null) {
			areSame = target1.gameObject.GetInstanceID() == target2.gameObject.GetInstanceID();
		}

		return areSame;

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		MouseOverTarget mouseOverTarget = null;
		if(Physics.Raycast (ray, out hit, 1000f)) {
			mouseOverTarget = hit.collider.gameObject.GetComponent<MouseOverTarget>();
		}
		CurrentTarget = mouseOverTarget;
	}


}
