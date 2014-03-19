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
	private List<Mechanism> mechanisms = new List<Mechanism>(); 

	private Vector2 position;
	public Vector2 Position {
		get {
			return position;
		}
		set {
			Vector2 newPosition = value;
			speed.x = newPosition.x - position.x;
			speed.y = newPosition.y - position.y;
			usesMechanicalPosition.onSettingMechanicalPosition(newPosition);
			position = newPosition;
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	public Vector2 getSpeed() {
		return speed;
	}

	public void setMechanisms() {
		foreach(Transform child in gameObject.transform) {
			Mechanism mechanism = child.transform.gameObject.GetComponent(typeof(Mechanism)) as Mechanism;
			if(mechanism != null) {
				mechanisms.Add (mechanism);
			}
		}
	}

	public void setStartPosition() {
		Vector2 startPosition = new Vector2(xStart, yStart);
		Position = startPosition;
	}

	// Update is called once per frame
	void Update () {
		updatePosition();
		updateMechansims();
	}

	void updateMechansims() {
		foreach(Mechanism mechanism in mechanisms) {
			mechanism.onMechanicalUpdate(this.position, this.speed);
		}
	}

	void updatePosition() {
		Vector2 currentPosition = Position;
		currentPosition.x = getUpdatedPositionAxis (movementAmount.x, currentPosition.x, invertXMovement);
		Position = currentPosition;
	}

	float getUpdatedPositionAxis(float movementAmountValue, float currentPosition, bool isInverted) {
		float inversionFactor = isInverted ? 1.0f : -1.0f;
		return currentPosition + (movementAmountValue * movementRate * inversionFactor);
	}
	


}

public interface UsesMechanicalPosition {

	void onSettingMechanicalPosition(Vector2 position);

}

public interface Mechanism {
	void onMechanicalUpdate(Vector2 position, Vector2 speed);
}
