using UnityEngine;
using System.Collections;

public class GetMouseAxis : MonoBehaviour {

	public delegate void MouseMoveAction(Vector2 mouseMovement);
	public static event MouseMoveAction OnMouseMove;
	public static event MouseMoveAction OnMouseMoveEnter;
	public static event MouseMoveAction OnMouseMoveExit;

	bool isMoving = false;
	public Vector2 MouseMovement {

		set{
			Vector2 newMovement = value;
			bool willBeMoving = newMovement.x != 0f || newMovement.y != 0f;
			if(willBeMoving && !isMoving) {
				isMoving = true;
				if(OnMouseMoveEnter != null) {
					OnMouseMoveEnter(newMovement);
				}
			}

			if(!willBeMoving && isMoving) {
				isMoving = false;
				if(OnMouseMoveExit != null) {
					OnMouseMoveExit(newMovement);
				}
			}

			if(willBeMoving && isMoving) {
				if(OnMouseMove != null) {
					OnMouseMove(newMovement);
				}

			}
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			Vector2 currentMouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
			MouseMovement = currentMouseMovement;
	}

	public void getMechanicalMoveAmount() {
//		float movementX = Input.GetAxis("Mouse X");
//		float movementY = Input.GetAxis("Mouse Y");
//		Vector2 mechanicalMoveAmount = new Vector2(movementX, movementY);
//		return mechanicalMoveAmount;
	}


}
