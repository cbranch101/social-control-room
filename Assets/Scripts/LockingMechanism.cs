using UnityEngine;
using System.Collections;

public class LockingMechanism : MonoBehaviour, Mechanism {

	public float lockDistance = .01f;
	private bool positiveEngaged = false;
	private bool negativeEngaged = false;
	// Use this for initialization
	void Start () {
		
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
				positiveEngaged = false;
				negativeEngaged = false;
			}
		}
	}

	void triggerPositiveEvent() {
		Debug.Log ("POSITIVE");
	}

	void triggerNegativeEvent() {
		Debug.Log ("NEGATIVE");
	}

	public void onMechanicalUpdate(Vector2 position, Vector2 speed) {
		triggerLockEvent (position, speed);
		
	}
}
