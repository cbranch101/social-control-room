using UnityEngine;
using System.Collections;

public class ApplyMechanicalMoveOnGrab : MonoBehaviour, Grabbable {
	
	public MechanicalMove targetMechanicalMove;
	public GameObject updaterObject;
	private UpdatesMechanicalMove updatesMechanicalMove;

	// Use this for initialization
	void Start () {

		updatesMechanicalMove = updaterObject.GetComponent(typeof(UpdatesMechanicalMove)) as UpdatesMechanicalMove;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onGrab() {

		targetMechanicalMove.movementAmount = updatesMechanicalMove.getMechanicalMoveAmount();
	}

	public void onGrabExit() {
		targetMechanicalMove.movementAmount = new Vector2(0, 0);
	}



}

public interface UpdatesMechanicalMove {
	Vector2 getMechanicalMoveAmount();
}
