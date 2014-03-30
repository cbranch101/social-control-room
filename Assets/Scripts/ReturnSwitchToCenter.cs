using UnityEngine;
using System.Collections;

public class ReturnSwitchToCenter : MonoBehaviour {

	private bool mechanismIsLocked = false;
	private bool shouldReturnToCenter = false;
	private GrabTarget grabTarget;
	public LockingMechanism lockingMechanism;
	public ClickButtonOnGrab clickButtonOnGrab;
	private MechanicalMove targetMechanicalMove;

	// Use this for initialization
	void Start () {
		grabTarget = gameObject.GetComponent<GrabTarget>();
		clickButtonOnGrab.OnClick += onButtonClick;
		lockingMechanism.OnLockEnter += onLockEnter;
		lockingMechanism.OnLockExit += onLockExit;
		targetMechanicalMove = gameObject.GetComponent<MechanicalMove>(); 
	}
	
	// Update is called once per frame
	void Update () {
		returnSwitchToCenter();
	}

	void onLockEnter(bool isPositive) {
		mechanismIsLocked = true;
	}
	
	void onLockExit(bool isPositive) {
		mechanismIsLocked = false;
	}
	
	void onButtonClick() {
		shouldReturnToCenter = true;
	}

	void returnSwitchToCenter() {
		if(!grabTarget.IsGrabbed) {
			if(shouldReturnToCenter || !mechanismIsLocked) {
				shouldReturnToCenter = false;
				Vector2 currentPosition = targetMechanicalMove.Position;
				if(currentPosition.x != .5f) {
					StartCoroutine(moveOverTime (currentPosition.x, .5f, .2f));
				}
			}
		}
	}
	
	IEnumerator moveOverTime(float startPosition, float endPosition, float timeToMove) {

		float percentageMoved = 0f;
		float movementRate = 1.0f / timeToMove;
		while(percentageMoved < 1.0f && !grabTarget.IsGrabbed) {
			percentageMoved += Time.deltaTime * movementRate;
			Vector2 currentPosition = targetMechanicalMove.Position;
			currentPosition.x = Mathf.Lerp (startPosition, endPosition, percentageMoved);
			targetMechanicalMove.Position = currentPosition;
			yield return null;
		}
	}


}
