using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	private Vector3 startingPositon;
	private bool canMove;
	public float Showtime = 0f;

	private Vector3 move;
	public Transform cam;
	private Vector3 camForward;
	private bool jump;

	[SerializeField] private float speed = 15;
	[SerializeField] private float max_speed = 25;
	[SerializeField] private float jump_power = 2;

	private const float groundedRay = 1f;
	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();

		GetComponent<Rigidbody>().maxAngularVelocity = max_speed;
	}


	private void Update()
	{
		// 
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		jump = Input.GetButton ("Jump");

		//calculating camera forward direction to change inputs
		camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
		move = (vertical * camForward + horizontal * cam.right).normalized;

		if (Showtime > 0f)
		{
			Showtime = Showtime - (Time.deltaTime);
		}
		else
		{
			speed = 15f;
		}
	}


	private void FixedUpdate()
	{
		rb.AddForce(move*speed);

		//raycast
		if (Physics.Raycast(transform.position, -Vector3.up, groundedRay) && jump)
		{
			//jump
			rb.AddForce(Vector3.up * jump_power, ForceMode.Impulse);
		}

		jump = false;
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			speed = 40f;
			Showtime = 3f;
		}

		if (other.gameObject.CompareTag ("Bounce"))
		{
			Debug.Log ("trampoline");
			GetComponent<Rigidbody>().AddForce(Vector3.up * 2000f);
		}
		if (other.gameObject.CompareTag("Death"))
		{
			rb.position = startingPositon;
			rb.velocity = rb.velocity * 0;
		}

	}

	public void Stop() {
		gameObject.GetComponent <Rigidbody> ().velocity = Vector3.zero;
		gameObject.GetComponent <Rigidbody> ().angularVelocity = Vector3.zero;
	}

	public void EnableMovement() {
		canMove = true;
	}

	public void DisableMovement() {
		canMove = false;
	}

	public void ResetPosition() {
		Stop ();
		transform.position = startingPositon;
	}
}