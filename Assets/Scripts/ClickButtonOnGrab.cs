using UnityEngine;
using System.Collections;

public class ClickButtonOnGrab : MonoBehaviour, Grabbable {

	public GameObject objectWithAnimator;
	private Animator animator;
	public delegate void ClickAction();
	public event ClickAction OnClick;

	// Use this for initialization
	void Start () {
		animator = objectWithAnimator.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onGrabEnter() {
		animator.SetBool ("ButtonPushed", true);
		OnClick();
	}	

	public void onGrab() {

	}	
	
	public void onGrabExit() {
		animator.SetBool ("ButtonPushed", false);
	}

}
