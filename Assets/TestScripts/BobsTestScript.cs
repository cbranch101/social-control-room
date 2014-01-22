using UnityEngine;
using System.Collections;

public class BobsTestScript : MonoBehaviour {

	public float Switched = 10.0f;
	protected Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetFloat("Switch L_R", 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat("Switch L_R", ((Switched) / 20));
	}
}