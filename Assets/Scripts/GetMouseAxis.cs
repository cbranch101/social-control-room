using UnityEngine;
using System.Collections;

public class GetMouseAxis : MonoBehaviour, UpdatesMechanicalMove {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector2 getMechanicalMoveAmount() {
		float movementX = Input.GetAxis("Mouse X");
		float movementY = Input.GetAxis("Mouse Y");
		Vector2 mechanicalMoveAmount = new Vector2(movementX, movementY);
		return mechanicalMoveAmount;
	}


}
