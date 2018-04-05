using UnityEngine;
using System.Collections;

public class newScript : MonoBehaviour 
{
	public GameObject ballObject;
	private Rigidbody rb;
	public Transform ballCamera;
	public float speed, turnSpeed;
	Vector3 forceDirection;

	void Start() {
		rb = ballObject.GetComponent<Rigidbody>();
	}


	void FixedUpdate() 
	{
		transform.position = ballObject.transform.position;
		if(Input.GetAxis("Vertical") != 0)
		{
			RollBall();
		}
		//calculate ball turning
		transform.Rotate((Vector3.up * Input.GetAxis("Horizontal") * turnSpeed), Space.World);
	}

	void RollBall()
	{
		//set force down camera's look direction
		forceDirection = ballCamera.transform.forward;

		//remove y force direction for angled camera
		forceDirection = new Vector3(forceDirection.x, 0, forceDirection.z);


		//add force to ball
		rb.AddForce(forceDirection.normalized * speed * (Input.GetAxis("Vertical")));
	}
}