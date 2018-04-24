using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour {

	public float min;
	public float max;
	public float dist = 14f;
	Vector3 rotate;

	// Use this for initialization
	void Start () {

		min=transform.position.y;
		max=transform.position.y + dist;

	}

	// Update is called once per frame
	void FixedUpdate () {

		transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*2,dist)+min, transform.position.z);

	}
}