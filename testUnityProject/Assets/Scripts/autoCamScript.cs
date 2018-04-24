using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoCamScript : MonoBehaviour 
{
	public GameObject ballObject;
	private Rigidbody rb;
	public Transform ballCamera;
	public float speed;
	public float turnSpeed;
	public float Showtime;
	Vector3 forceDirection;
	float speedInitial;

	Vector3 camForward; 

	bool oneTime;

	void Start() {
		rb = ballObject.GetComponent<Rigidbody>();
		Showtime = 0f;
		speed = ballObject.GetComponent<finalPlayerScript> ().speed;
		speedInitial = speed;
	}

	void Update() 
	{
		if (oneTime) {
			oneTime = false;
		}
			
		if (Showtime > 0f) {
			Showtime = Showtime - (Time.deltaTime);
		} else {
			speed = speedInitial;
		}

		transform.position = ballObject.transform.position;
		if(Input.GetAxis("Vertical") != 0)
		{
			RollBall();
		}
		//calculate ball turning
		//transform.Rotate ((Vector3.up * Input.GetAxis ("Horizontal") * turnSpeed * Time.deltaTime), Space.World);

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime, Space.World);
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime, Space.World);
	}

	void RollBall()
	{
		//set force down camera's look direction
		forceDirection = ballCamera.transform.forward;

		//remove y force direction for angled camera
		forceDirection = new Vector3(forceDirection.x, 0, forceDirection.z);


		//add force to ball
		//rb.AddForce(forceDirection.normalized * speed * (Input.GetAxis("Vertical")));

		camForward = forceDirection.normalized * speed * (Input.GetAxis ("Vertical"));
	}

	private void FixedUpdate () {
		rb.AddForce (camForward);
	}
}
