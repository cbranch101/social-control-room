using UnityEngine;
using System.Collections;

public class LeverController : MonoBehaviour {

	public string xPositionParameter = "none";
	public float xStart = 0.0f;
	public bool invertXParamater = false;
	public string yPositionParameter = "none";
	public float yStart = 0.0f;
	public bool invertYParamter = false;
	public float movementRate = 5.0f;
	public bool isTwoDimensional = false;
	public Renderer controlledMesh;
	public GameObject objectWithCollider;
	public GameObject objectWithMechanimController;
	// Use this for initialization
	void Awake() {
		MouseOverTarget mouseOverTarget = objectWithCollider.AddComponent<MouseOverTarget>();
		GrabTarget grabTarget = gameObject.AddComponent<GrabTarget>();
		grabTarget.mouseOverTarget = mouseOverTarget;
		configureMouseOverEffects(mouseOverTarget, grabTarget);
		configureMovementEffects(mouseOverTarget, grabTarget);
	}

	public void configureMovementEffects(MouseOverTarget mouseOverTarget, GrabTarget grabTarget) {
		TranslateMouseMovementToMechanicalMovement translateMove = gameObject.AddComponent<TranslateMouseMovementToMechanicalMovement>();
		translateMove.grabTarget = grabTarget;
		MechanicalMove mechanicalMove = gameObject.AddComponent<MechanicalMove>();
		translateMove.mechanicalMove = mechanicalMove;
		MechanicalController mechanicalController = gameObject.AddComponent<MechanicalController>();

		configureMechanicalMove(mechanicalMove);
		configureMechanicalController(mechanicalController, mechanicalMove);
	}

	public void configureMouseOverEffects(MouseOverTarget mouseOverTarget, GrabTarget grabTarget) {
		ChangeColorOnMouseOver changeColorOnMouseOver = gameObject.AddComponent<ChangeColorOnMouseOver>();
		changeColorOnMouseOver.mouseOverTarget = mouseOverTarget;
		changeColorOnMouseOver.targetMesh = controlledMesh;
		changeColorOnMouseOver.grabTarget = grabTarget;
		ChangeColorOnGrab changeColorOnGrab = gameObject.AddComponent<ChangeColorOnGrab>();
		changeColorOnGrab.mouseOverTarget = mouseOverTarget;
		changeColorOnGrab.grabTarget = grabTarget;
		changeColorOnGrab.targetMesh = controlledMesh;

	}

	public void configureMechanicalMove(MechanicalMove targetMechanicalMove) {
		targetMechanicalMove.movementRate = movementRate;
		targetMechanicalMove.invertXMovement = invertXParamater;
		targetMechanicalMove.invertYMovement = invertXParamater;
		targetMechanicalMove.xStart = xStart;
		targetMechanicalMove.yStart = yStart;
		targetMechanicalMove.invertYMovement = invertXParamater;
	}

	public void configureMechanicalController(MechanicalController mechanicalController, MechanicalMove mechanicalMove) {
		mechanicalController.animator = objectWithMechanimController.GetComponent<Animator>();
		mechanicalController.mechanicalMove = mechanicalMove;
		mechanicalController.xPositionParameter = xPositionParameter;
		mechanicalController.yPositionParameter = yPositionParameter;
		mechanicalController.isTwoDimensional = isTwoDimensional;
	}


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
