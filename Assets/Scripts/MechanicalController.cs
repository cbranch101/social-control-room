using UnityEngine;
using System.Collections;

public class MechanicalController : MonoBehaviour, UsesMechanicalPosition {

	public Animator animator;
	public string xPositionParameter = "none";
	public string yPositionParameter = "none";
	public bool isTwoDimensional = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onSettingMechanicalPosition(Vector2 position) {

		animator.SetFloat(xPositionParameter, position.x);
		if(isTwoDimensional) {
			animator.SetFloat(yPositionParameter, position.y);
		}
	}
}
