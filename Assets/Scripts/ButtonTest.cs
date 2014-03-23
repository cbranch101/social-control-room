using UnityEngine;
using System.Collections;

public class ButtonTest : MonoBehaviour {

	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)) {
			animator.SetBool ("ButtonPushed", true);
		} else {
			animator.SetBool ("ButtonPushed", false);
		}
	}
}
