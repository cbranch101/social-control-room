using UnityEngine;
using System.Collections;

public class GrabbableMechanicalCollider : MonoBehaviour {

	public string xPositionParameter = "none";
	public float xStart = 0.0f;
	public bool invertXParamater = false;
	public string yPositionParameter = "none";
	public float yStart = 0.0f;
	public bool invertYParamter = false;
	public float movementRate = 5.0f;
	public bool isTwoDimensional = false;
	public Renderer meshToHighlight;
	public GameObject objectWithMecanimController;
	public GameObject mechanicalMoveUpdaterObject;
	private MechanicalMove targetMechanicalMove;

	// Use this for initialization
	void Start () {
		configureCollider();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void configureCollider() {
		gameObject.AddComponent<MouseOverTarget>();
		gameObject.AddComponent<ChangeColorOnMouseOver>();
		gameObject.GetComponent<ChangeColorOnMouseOver>().targetMesh = meshToHighlight;
		gameObject.AddComponent<ChangeColorOnGrab>();
		gameObject.GetComponent<ChangeColorOnGrab>().targetMesh = meshToHighlight;
		gameObject.AddComponent<GrabTarget>();
		gameObject.AddComponent<ApplyMechanicalMoveOnGrab>();
		configureObjectWithMecanimController();
		gameObject.GetComponent<ApplyMechanicalMoveOnGrab>().targetMechanicalMove = targetMechanicalMove;
		gameObject.GetComponent<ApplyMechanicalMoveOnGrab>().updaterObject = mechanicalMoveUpdaterObject;
		targetMechanicalMove.setStartPosition();
	}

	public void configureObjectWithMecanimController(){
		objectWithMecanimController.AddComponent<MechanicalMove>();
		objectWithMecanimController.AddComponent<MechanicalController>();
		configureMechanicalController();
		configureMechanicalMove();
	}

	public void configureMechanicalMove() {
		targetMechanicalMove = objectWithMecanimController.GetComponent<MechanicalMove>();
		UsesMechanicalPosition usesMechanicalPosition = objectWithMecanimController.GetComponent(typeof(UsesMechanicalPosition)) as UsesMechanicalPosition;
		targetMechanicalMove.usesMechanicalPosition = usesMechanicalPosition;
		targetMechanicalMove.movementRate = movementRate;
		targetMechanicalMove.invertXMovement = invertXParamater;
		targetMechanicalMove.invertYMovement = invertXParamater;
		targetMechanicalMove.xStart = xStart;
		targetMechanicalMove.yStart = yStart;
		targetMechanicalMove.invertYMovement = invertXParamater;
		targetMechanicalMove.setMechanisms();
	}

	public void configureMechanicalController() {
		MechanicalController mechanicalController = objectWithMecanimController.GetComponent<MechanicalController>();
		mechanicalController.animator = objectWithMecanimController.GetComponent<Animator>();
		mechanicalController.xPositionParameter = xPositionParameter;
		mechanicalController.yPositionParameter = yPositionParameter;
		mechanicalController.isTwoDimensional = isTwoDimensional;
	}
	
}
