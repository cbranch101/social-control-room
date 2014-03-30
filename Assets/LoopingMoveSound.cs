using UnityEngine;
using System.Collections;

public class LoopingMoveSound : MonoBehaviour {
	
	public LockingMechanism lockingMechanism;
	public AudioClip loopClip;
	public float volume = 1f;
	private AudioSource audioSource;
	private float lastStopped = 0;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.volume = volume;
		audioSource.loop = true;
		audioSource.clip = loopClip;
		MechanicalMove targetMechanicalMove = gameObject.GetComponent<MechanicalMove>();
		targetMechanicalMove.OnEnterMechanicalMove += onLockMoveEnter;
		targetMechanicalMove.OnExitMechanicalMove += onLockMoveExit;
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
