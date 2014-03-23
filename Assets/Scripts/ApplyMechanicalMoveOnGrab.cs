using UnityEngine;
using System.Collections;

public class ApplyMechanicalMoveOnGrab : MonoBehaviour, Grabbable {

	private LockingMechanism lockingMechanism;
	private bool isGrabbed = false;
	private ClickButtonOnGrab targetButton;
	public MechanicalMove targetMechanicalMove;
	public GameObject updaterObject;
	private UpdatesMechanicalMove updatesMechanicalMove;
	private bool mechanismIsLocked = false;
	private bool lockShouldBeReleased = false;

	// Use this for initialization
	void Start () {
		lockingMechanism = GameObject.Find ("LockingMechanism").GetComponent<LockingMechanism>();
		targetButton = GameObject.Find ("Button_Base").GetComponent<ClickButtonOnGrab>();
		targetButton.OnClick += onButtonClick;
		updatesMechanicalMove = updaterObject.GetComponent(typeof(UpdatesMechanicalMove)) as UpdatesMechanicalMove;
		lockingMechanism.OnLockExit += onLockExit;
		lockingMechanism.OnLockEnter += onLockEnter;
	}

	void onLockEnter(bool isPositive) {
		mechanismIsLocked = true;
	}

	void onLockExit(bool isPositive) {
		mechanismIsLocked = false;
	}

	void onButtonClick() {
		lockShouldBeReleased = true;
	}
	
	// Update is called once per frame
	void Update () {
		returnSwitchToCenter();
	}

	void returnSwitchToCenter() {
		if(!isGrabbed) {
			if(lockShouldBeReleased || !mechanismIsLocked) {
				lockShouldBeReleased = false;
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
		while(percentageMoved < 1.0f && !isGrabbed) {
			percentageMoved += Time.deltaTime * movementRate;
			Vector2 currentPosition = targetMechanicalMove.Position;
			currentPosition.x = Mathf.Lerp (startPosition, endPosition, percentageMoved);
			targetMechanicalMove.Position = currentPosition;
			yield return null;
		}
	}

	public void onGrabEnter() {
		
	}


	public void onGrab() {
		isGrabbed = true;

		targetMechanicalMove.movementAmount = updatesMechanicalMove.getMechanicalMoveAmount();
	}

	public void onGrabExit() {
		isGrabbed = false;
		targetMechanicalMove.movementAmount = new Vector2(0, 0);
	}



}

public interface UpdatesMechanicalMove {
	Vector2 getMechanicalMoveAmount();
}
