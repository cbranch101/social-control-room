using UnityEngine;
using System.Collections;

public class TextTest : MonoBehaviour {

	CCText textMesh;
	// Use this for initialization
	void Start () {
		textMesh = GetComponent<CCText>();
		textMesh.Text = "'Eat all the food!' - 11 things our creative director, Christy, learned at SXSW: http://blog.movementstrategy.com/11-things-i-learned-at-sxsw/";
	}
	
	// Update is called once per frame
	void Update () {

	}
}
