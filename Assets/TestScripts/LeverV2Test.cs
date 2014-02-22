using UnityEngine;
using System.Collections;

public class LeverV2Test : MonoBehaviour {

	public float horizontalPercentFlipped = 0.0f;
	//public float verticalPercentFlipped = 0.0f;
	public float flipSpeed = 0.1f;
	private bool isFlipped = false;
	protected Animator animator;
	protected bool isGrabbed = false;
	public SkinnedMeshRenderer targetMesh;
	public string horizontalParameter;
	private float previousHorizontalPercentFlipped;
	private string movementDirection;
	private string previousMovementDirection;
	private AudioSource audioSource;
	//public string verticalParamter;
	
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonUp(0)) {
			isGrabbed = false;
			Screen.showCursor = true;
		}
		changeSwitchColor ();
		updateFlippedPercent();
		animator.SetFloat(horizontalParameter, horizontalPercentFlipped);
		triggerSound ();
		//animator.SetFloat(verticalParamter, verticalPercentFlipped);
		
	}

	void handleDirection() {

	}
	
	void triggerSound() {
		if(horizontalPercentFlipped > .9f) {
			if(!audioSource.isPlaying && !isFlipped) {
				audioSource.Play();
				isFlipped = false; 
			}
		}
		if(horizontalPercentFlipped < .1f) {

			if(!audioSource.isPlaying && isFlipped) {
				isFlipped = false;
				audioSource.Play();
			}
			
		}
	}
	
	void changeSwitchColor() {
		
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast (ray, out hit, 1000f)) {
			if(!isGrabbed) {
				targetMesh.renderer.material.color = Color.red;
			}
			
			if(Input.GetMouseButtonDown(0)) {
				isGrabbed = true;
				Screen.showCursor = false;
			}
			
		} else {
			if(!isGrabbed) {
				targetMesh.renderer.material.color = Color.black;
			}
		}
	}
	
	void updateFlippedPercent() {
		if(isGrabbed) {
			previousHorizontalPercentFlipped = horizontalPercentFlipped;
			horizontalPercentFlipped = horizontalPercentFlipped + (flipSpeed * Input.GetAxis("Mouse X"));
			previousMovementDirection = movementDirection;
			movementDirection = previousHorizontalPercentFlipped > horizontalPercentFlipped ? "positive" : "negative";
			//percentFlipped = Mathf.Clamp(newPercentFlipped, 0.0f, 1.0f);
		}
	}
	
	void OnMouseOver() {
		Debug.Log ("Mouse Over!");
	}
	
	void OnMouseExit() {
		Debug.Log ("EXIT!");
	}
}
