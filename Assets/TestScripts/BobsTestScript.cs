using UnityEngine;
using System.Collections;

public class BobsTestScript : MonoBehaviour {
	[SerializeField]
	AnimationCurve bobbingCurve;
	[Range(0,100)]
	public float Left_Right = 0.0f;

	[Range(0,100)]
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

		animator.SetFloat("Switch L_R", (bobbingCurve.Evaluate(Left_Right / 100)));
		animator.SetFloat("Switch U_D", ((Up_Down) / 20));
	}
}