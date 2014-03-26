using UnityEngine;
using System.Collections;

public class LockingMechanism : MonoBehaviour, Mechanism {

	public float lockDistance = .01f;
	private bool positiveEngaged = false;
	private bool negativeEngaged = false;
	public delegate void LockEnterAction(bool isPositive);
	public delegate void LockExitAction(bool isPositive);
	public event LockEnterAction OnLockEnter;
	public event LockExitAction OnLockExit;
	public AudioClip switchMovingSound;
	private AudioSource audioSource;
	private float lastStopped = 0;



	// Use this for initialization
	void Start () {
		audioSource = GameObject.Find ("AudioSource").GetComponent<AudioSource>();
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
		if(speed.x != 0f) {
			if(!audioSource.isPlaying) {
				audioSource.clip = switchMovingSound;
				audioSource.Play();
			}
		} else {
			float timeSinceStop = Time.time - lastStopped;
			if(audioSource.isPlaying && timeSinceStop > .8f) {
				audioSource.Pause();
				lastStopped = Time.time;
			}
		} 
		triggerLockEvent (position, speed);
		
	}


}
