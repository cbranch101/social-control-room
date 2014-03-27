using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MechanicalMove : MonoBehaviour {

	[HideInInspector]
	public Vector2 movementAmount;
	private Vector2 speed = new Vector2(0f, 0f);
	public float movementRate = 0.5f;
	public float xStart = 0.0f;
	public float yStart = 0.0f;
	public bool invertXMovement = false;
	public bool invertYMovement = false;
	public UsesMechanicalPosition usesMechanicalPosition;
	public delegate void UpdateAction(Vector2 position, Vector2 speed);
	public event UpdateAction OnMechanicalMove;
	public event UpdateAction OnEnterMechanicalMove;
	public event UpdateAction OnExitMechanicalMove;


	private Vector2 position;
	private bool isMoving = false;
	public Vector2 Position {
		get {
			return position;
		}
		set {
			Vector2 newPosition = value;
			speed.x = newPosition.x - position.x;
			speed.y = newPosition.y - position.y;
			usesMechanicalPosition.onSettingMechanicalPosition(newPosition);
			bool willBeMoving = (speed.x != 0f);
			if(willBeMoving && !isMoving) {
				OnEnterMechanicalMove(speed, position);
				isMoving = true;
			}

			if(!willBeMoving && isMoving) {
				OnExitMechanicalMove(speed, position);
				isMoving = false;
			}

			position = newPosition;
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	public Vector2 getSpeed() {
		return speed;
	}
	
	public void setStartPosition() {
		Vector2 startPosition = new Vector2(xStart, yStart);
		Position = startPosition;
	}

	// Update is called once per frame
	void Update () {
		updatePosition();
		OnMechanicalMove(position, speed);
	}

	void updatePosition() {
		Vector2 currentPosition = Position;
		currentPosition.x = getUpdatedPositionAxis (movementAmount.x, currentPosition.x, invertXMovement);
		Position = currentPosition;
	}

	float getUpdatedPositionAxis(float movementAmountValue, float currentPosition, bool isInverted) {
		float inversionFactor = isInverted ? 1.0f : -1.0f;
		return currentPosition + (Time.deltaTime * movementAmountValue * movementRate * inversionFactor);
	}
	


}

public interface UsesMechanicalPosition {

	void onSettingMechanicalPosition(Vector2 position);

}
