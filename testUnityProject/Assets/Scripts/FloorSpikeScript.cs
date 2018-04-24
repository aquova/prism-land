using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpikeScript : MonoBehaviour {

    public int direction;
    public float speed;

	private void FixedUpdate()
	{
        transform.position = new Vector3(transform.position.x, transform.position.y + (direction*speed), transform.position.z);
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("UpperBound") || other.CompareTag("LowerBound")) {
            direction = -direction;
        }
	}
}
