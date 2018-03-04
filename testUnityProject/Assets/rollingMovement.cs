using UnityEngine;
using System.Collections;

public class rollingMovement : MonoBehaviour {

	private float speed = 15f;
	public float Showtime = 0f;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if (Showtime > 0f)
		{
			Showtime = Showtime - (Time.deltaTime);
		}
		else {
			speed = 15f;
		}
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
			GetComponent<Rigidbody>().AddForce(Vector3.up * 1000f);
		}

	}
}