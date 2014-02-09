using UnityEngine;
using System.Collections;

public class LeverTest : MonoBehaviour {
	
	public float horizontalPercentFlipped = 0.0f;
	//public float verticalPercentFlipped = 0.0f;
	public float flipSpeed = 0.1f;
	private bool isFlipped = false;
	protected Animator animator;
	protected bool isGrabbed = false;
	public MeshRenderer targetMesh;
	public string horizontalParameter;
	private AudioSource audioSource;
	//public string verticalParamter;
	
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		animator.SetFloat(horizontalParameter, 0.5f);
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

	void triggerSound() {
		if(horizontalPercentFlipped > .9f) {

			if(!audioSource.isPlaying && !isFlipped) {
				audioSource.Play();
				isFlipped = true;
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
			//verticalPercentFlipped = verticalPercentFlipped + (flipSpeed * Input.GetAxis("Mouse Y") * -1);
			horizontalPercentFlipped = horizontalPercentFlipped + (flipSpeed * Input.GetAxis("Mouse X") * -1);

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
