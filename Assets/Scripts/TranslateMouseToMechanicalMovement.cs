using UnityEngine;
using System.Collections;

public class TranslateMouseMovementToMechanicalMovement : MonoBehaviour {

	public MechanicalMove mechanicalMove;
	private Vector2 mouseMovement;
	public GrabTarget grabTarget;
	// Use this for initialization
	void Start () {
		GetMouseAxis.OnMouseMove += onMouseMove;
		GetMouseAxis.OnMouseMoveExit += onMouseMoveExit;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void onMouseMove(Vector2 newMouseMovement) {
		if(grabTarget.IsGrabbed) {
			mechanicalMove.movementAmount = newMouseMovement;
		}
	}

	void onMouseMoveExit(Vector2 newMouseMovement) {
		mechanicalMove.movementAmount = new Vector2(0f, 0f);
	}
	
}
