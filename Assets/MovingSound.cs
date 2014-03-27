using UnityEngine;
using System.Collections;

public class MovingSound : MonoBehaviour {

	public LockingMechanism lockingMechanism;
	public AudioClip switchMovingSound;
	private AudioSource audioSource;
	private float lastStopped = 0;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		lockingMechanism.OnLockMove += onLockMove;
		lockingMechanism.OnLockMoveEnter += onLockMoveEnter;
		lockingMechanism.OnLockMoveExit += onLockMoveExit;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onLockMove(Vector2 position, Vector2 speed) {
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
	}

	void onLockMoveEnter(Vector2 position, Vector2 speed) {
		Debug.Log ("enter");
	}

	void onLockMoveExit(Vector2 position, Vector2 speed) {
		Debug.Log ("exit");
	}
}
