using UnityEngine;
using System.Collections;

public class ColorManager : MonoBehaviour {

	public Color mouseOverColor;
	public Color grabbedColor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setMouseOverColor(Renderer targetMesh, Color defaultColor, bool isMousedOver) {
		Color colorToSet = isMousedOver ? mouseOverColor : defaultColor;
		setColor(colorToSet, targetMesh);
	}
	
	private void setColor(Color colorToSet, Renderer targetMesh) {
		targetMesh.renderer.material.color = colorToSet;
	}

}
