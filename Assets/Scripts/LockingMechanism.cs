using UnityEngine;
using System.Collections;

public class LockingMechanism : MonoBehaviour{

	public float lockDistance = .01f;
	private bool positiveEngaged = false;
	private bool negativeEngaged = false;
	public delegate void LockEnterAction(bool isPositive);
	public delegate void LockExitAction(bool isPositive);
	public event LockEnterAction OnLockEnter;
	public event LockExitAction OnLockExit;
	public delegate void LockAction(Vector2 position, Vector2 speed);


	// Use this for initialization
	void Start () {
		MechanicalMove targetMechanicalMove = gameObject.GetComponent<MechanicalMove>();
		targetMechanicalMove.OnMechanicalMove += onMechanicalUpdate;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void triggerLockEvent(Vector2 position, Vector2 speed) {
		float currentPosition = position.x;
		float positiveLockPoint = 1.0f - lockDistance;
		float negativeLockPoint = 0.0f + lockDistance;

		if(currentPosition > positiveLockPoint) {
			if(!positiveEngaged) {
				triggerPositiveEvent();
				positiveEngaged = true;
			}
		}

		if(currentPosition < negativeLockPoint) {
			if(!negativeEngaged) {
				triggerNegativeEvent();
				negativeEngaged = true;
			}

		}

		if(currentPosition >= negativeLockPoint && currentPosition <= positiveLockPoint) {
			if(positiveEngaged || negativeEngaged) {
				triggerExitEvent();
			}
		}
	}


	void triggerExitEvent() {

		if(OnLockExit != null) {
			if(positiveEngaged) {
				OnLockExit(true);
			} else {
				OnLockExit(false);
			}
		}
		positiveEngaged = false;
		negativeEngaged = false;

	}

	void triggerPositiveEvent() {
		if(OnLockEnter != null) {
			OnLockEnter(true);
		}

	}

	void triggerNegativeEvent() {
		if(OnLockEnter != null) {
			OnLockEnter(false);
		}
	}

	public void onMechanicalUpdate(Vector2 position, Vector2 speed) {
		triggerLockEvent (position, speed);
		
	}


}
