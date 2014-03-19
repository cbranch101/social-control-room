using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	public Renderer targetMesh;
	public Color defaultColor;

	// Use this for initialization
	void Start () {
		defaultColor = targetMesh.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setColor(Color colorToSet) {
		targetMesh.renderer.material.color = colorToSet;
	}
}
