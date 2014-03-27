using UnityEngine;
using System.Collections;

public class LoopingMoveSound : MonoBehaviour {
	
	public LockingMechanism lockingMechanism;
	public AudioClip loopClip;
	private AudioSource audioSource;
	private float lastStopped = 0;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.loop = true;
		audioSource.clip = loopClip;
		lockingMechanism.OnLockMove += onLockMove;
		lockingMechanism.OnLockMoveEnter += onLockMoveEnter;
		lockingMechanism.OnLockMoveExit += onLockMoveExit;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void onLockMove(Vector2 position, Vector2 speed) {
	}
	
	void onLockMoveEnter(Vector2 position, Vector2 speed) {
		audioSource.Play();

	}
	
	void onLockMoveExit(Vector2 position, Vector2 speed) {
		audioSource.Pause();
	}
}
