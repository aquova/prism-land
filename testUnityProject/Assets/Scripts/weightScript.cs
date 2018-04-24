using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weightScript : MonoBehaviour {
	private Rigidbody rb;
	bool bajando = false;
	float y;
	int thrust = 10;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (bajando && transform.position.y > y)
		{
			bajando = false;
			rb.AddForce(rb.velocity * thrust);
		}
		if (!bajando && transform.position.y < y)
		{
			bajando = true;
		}
		y = transform.position.y;

	}
}
