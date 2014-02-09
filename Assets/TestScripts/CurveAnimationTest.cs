using UnityEngine;
using System.Collections;

public class CurveAnimationTest : MonoBehaviour {

	public float Left_Right = 0.0f;
	public float Up_Down = 0.0f;
	protected Animator animator;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetFloat("Switch L_R", 0.0f);
		animator.SetFloat("Switch U_D", 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat("Switch L_R", ((Left_Right) / 20));
		animator.SetFloat("Switch U_D", ((Up_Down) / 20));
	}
}
