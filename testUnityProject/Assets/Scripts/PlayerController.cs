using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
    private Vector3 startingPositon;
    private bool canMove;
	public float speed;
    public float Showtime = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
        startingPositon = transform.position;
        canMove = true;
	}

	private void FixedUpdate()
	{
        if (canMove) {
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");

            Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
            movement = Camera.main.transform.TransformDirection (movement);
            movement.y = 0.0f;
            rb.AddForce (movement * speed);

            if (Showtime > 0f) {
                Showtime = Showtime - (Time.deltaTime);
            } else {
                speed = 15f;
            }
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