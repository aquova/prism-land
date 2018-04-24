using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointScript : MonoBehaviour {

	public bool checkpointReached;

	public Material unactivated;
	public Material activated;

	void Start () {
		checkpointReached = false;
		this.GetComponent<Renderer>().material = unactivated;
		//this.GetComponent<Renderer>().material = activated;
	}

	// Update is called once per frame
	void Update () {
		if (checkpointReached) {
			this.GetComponent<Renderer>().material = activated;
		} else {
			this.GetComponent<Renderer>().material = unactivated;
		}
	}

	void SetActive () {
		checkpointReached = true;
	}
}