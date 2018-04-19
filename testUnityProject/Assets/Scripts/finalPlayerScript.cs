using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class finalPlayerScript : MonoBehaviour
{
	private Rigidbody rb;
	private Vector3 startingPositon;
	private bool canMove;
	public float speed;
	float Showtime = 0f;
	Vector3 movement;
	private const float groundedRay = 1f;
	private bool jump;

	//cam
	public Transform cam;
	Vector3 camForward;

	//private bool ground;
	//public float jump;
	public bool jump1;
	[SerializeField] float jumpSpeed = 15f;

	//public float raycast;
	private float speedInitial;

	// Things needed for pausing
	bool pausedPressed;
	bool oldPausedPressed;
	GameObject[] pauseObjects;
	public GameObject SpeedParticles; 
	private GameObject currentParitcles;

	//switching between the cameras
	[HideInInspector] public bool autoCam = false; //added hideInInspector since if ppl try to change it here the game breaks
	public GameObject autoCamEmpty;

	//trampoline force
	[SerializeField] float trampolineForce = 500f;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		startingPositon = transform.position;
		speedInitial = speed;
		// We don't really need canMove, I don't think it's ever called
		// and timeScale can serve the same built-in function - Austin
		canMove = true;
		jump1 = true;
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("pausedItem");
		//hidePaused();
	}

	private void Update()
	{
		if (autoCam == false) {

			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			jump = Input.GetButton ("Jump");

			//movement = moveHorizontal, 0, moveVertical;
			// Modified: movement is not attached to vertical camera
			//movement = cam.TransformDirection(movement);

			camForward = Vector3.Scale (cam.forward, new Vector3 (1, 0, 1)).normalized;
			movement = (moveVertical * camForward + moveHorizontal * cam.right).normalized;

			// We need to detach jump movement from the camera angle

			if (Showtime > 0f) {
				Showtime = Showtime - (Time.deltaTime);
			} else {
				speed = speedInitial;
				if (currentParitcles != null) {
					Destroy (currentParitcles);
				}
			}
		}
		if (jump1 && Input.GetButtonDown ("Jump")) {
			// TODO: Add ray debug draw to make sure raycasting is in the right direction
			movement.y = jumpSpeed;
			jump1 = false;
		} else {
			movement.y = 0;
		}

		if (autoCam == false) {
			rb.AddForce (movement * speed);
		}		
	}

/*	private void FixedUpdate()
	{
		if (autoCam == false) {
			rb.AddForce (movement * speed);
		}

		//raycast
		if (Physics.Raycast(transform.position, -Vector3.up, groundedRay) && jump)
		{
			//jump
			rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
		}

		jump = false;

	}*/

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("We have collided " + other.gameObject.tag);
		if (other.gameObject.CompareTag("Pick Up"))
		{
			if (currentParitcles != null)
			{
				Destroy(currentParitcles);
			}

			GameObject particles = Instantiate(SpeedParticles, transform.position, transform.rotation);
			particles.transform.parent = transform;
			currentParitcles = particles;

			// Creates another thread that waits 10 seconds then respawns the pick up
			StartCoroutine(TemporarilyDisable(other.gameObject, 10, null));

			speed = 40f;
			Showtime = 3f;

			if (autoCam == true) {
				autoCamEmpty.GetComponent<autoCamScript> ().speed = 40f;
				autoCamEmpty.GetComponent<autoCamScript> ().Showtime = 3f;
			}

		}


		if (other.gameObject.CompareTag("Death"))
		{
			rb.position = startingPositon;
			rb.velocity = rb.velocity * 0;
		}
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("SafeToJump")) {
			jump1 = true;
		}
		if (collision.gameObject.CompareTag("Boom")) {
			collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000.0f, collision.gameObject.GetComponent<Rigidbody>().position, 30000.0f);
		}
		if (collision.gameObject.CompareTag("Bounce")) {
			//Debug.Log("trampoline");
			if (gameObject.transform.position.y  >= collision.gameObject.transform.position.y + collision.gameObject.GetComponent<Renderer>().bounds.size.y/2)	{
				GetComponent<Rigidbody>().AddForce(Vector3.up * 2500f);
			}
		}
	}
	public void Stop()
	{
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	}

	public void ResetPosition()
	{
		Stop();
		transform.position = startingPositon;
	}

	// Temporarily deactivates the specified game object. Do Not call it on the player game object or it will never respawn
	IEnumerator TemporarilyDisable(GameObject obj, int time, Action callback)
	{
		obj.SetActive(false);
		yield return new WaitForSeconds(time);
		obj.SetActive(true);

		// Potential extra things we may want to do after waiting the specified time
		if (callback != null)
		{
			callback();
		}
	}
}