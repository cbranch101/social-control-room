using UnityEngine;
using System.Collections;

public class LockSound : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip lockClip;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.clip = lockClip;
		LockingMechanism lockingMechanism = gameObject.GetComponent<LockingMechanism>();
		lockingMechanism.OnLockEnter += playClip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void playClip(bool isPositive) {
		audioSource.Play();
	}
}
