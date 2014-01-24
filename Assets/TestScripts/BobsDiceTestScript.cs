using UnityEngine;
using System.Collections;

public class BobsDiceTestScript : MonoBehaviour {

	public float Openness = 0.0F;
	protected Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetFloat("Open_Closed", 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat("Open_Closed", ((Openness) / 20));
	}
}