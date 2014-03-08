using UnityEngine;
using System.Collections;

public class MouseOverTarget : MonoBehaviour {
	
	private MouseOverable mouseOverable;
	// Use this for initialization
	void Start () {
		mouseOverable = gameObject.GetComponent(typeof(MouseOverable)) as MouseOverable;
		if(mouseOverable == null) {
			Debug.Log ("No Mouserable component attatched to " + gameObject.name);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void triggerOnMouseOverEnter() {
		mouseOverable.onMouseOverEnter();
	}

	public void triggerOnMouseOverExit() {
		mouseOverable.onMouseOverExit();
	}

}

public interface MouseOverable {

	void onMouseOverEnter();

	void onMouseOverExit();

}
