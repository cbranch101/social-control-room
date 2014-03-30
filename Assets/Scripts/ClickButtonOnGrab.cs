using UnityEngine;
using System.Collections;

public class ClickButtonOnGrab : MonoBehaviour {

	public GameObject objectWithAnimator;
	private Animator animator;
	public delegate void ClickAction();
	public event ClickAction OnClick;
	public GrabTarget grabTarget;

	// Use this for initialization
	void Start () {
		grabTarget.OnGrabEnter += onGrabEnter;
		grabTarget.OnGrabExit += onGrabExit;
		animator = objectWithAnimator.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onGrabEnter() {
		animator.SetBool ("ButtonPushed", true);
		if(OnClick != null) {
			OnClick();
		}
	}	
	
	public void onGrabExit() {
		animator.SetBool ("ButtonPushed", false);
	}

}
