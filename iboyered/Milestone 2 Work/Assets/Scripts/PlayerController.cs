using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public float speed;
	public Transform cam;
	// Jump stuff
	private bool ground;
	public float jumpSpeed;
	public float jump;
	public float raycast;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, jump * jumpSpeed, moveVertical);
		movement = cam.TransformDirection (movement);
		//movement.y = 0.0f;

		// Changed to only make horizontal movements affect while grounded
		if (ground)
		{
			rb.AddForce(movement * speed);
		}

		// Jump stuff
		if (Physics.Raycast(transform.position, Vector3.down, raycast))
		{
			ground = true;
		} else {
			ground = false;
		}

		if (Input.GetKeyDown("space") && ground)
		{
			// TODO: Add ray debug draw to make sure raycasting is in the right direction
			jump = 1.0f;
		} else {
			jump = 0.0f;
		}
	}
}