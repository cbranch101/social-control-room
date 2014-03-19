using UnityEngine;
using System.Collections;

public class EventReceiverTest : MonoBehaviour {



	// Use this for initialization
	void Start () {
		QueryEventTest.OnRequestReceived += Message;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Message() {
		Debug.Log ("Message received");
	}
}
