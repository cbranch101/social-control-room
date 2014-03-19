using UnityEngine;
using System.Collections;

public class QueryEventTest : MonoBehaviour {

	public delegate void RequestReceived();
	public static event RequestReceived OnRequestReceived;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		OnRequestReceived();
	}
}
