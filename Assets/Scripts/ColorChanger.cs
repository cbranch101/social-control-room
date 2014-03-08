using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour {

	public Renderer targetMesh;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setColor(Color colorToSet) {
		targetMesh.renderer.material.color = colorToSet;
	}
}
