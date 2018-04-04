using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
    private Vector3 startingPositon;
    private bool canMove;
	public float speed;
    public float Showtime = 0f;
    public Transform cam;
    private bool ground;
    public float jump;
    public float jumpSpeed;
    public float raycast;

    bool pausedPressed;
    bool oldPausedPressed;
    GameObject[] pauseObjects;
    public GameObject SpeedParticles; 
    private GameObject currentParitcles;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
        startingPositon = transform.position;
        // I'm not sure we need this. The built-in timeScale function does basically the same thing for us
        canMove = true;
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("pausedItem");
        hidePaused();
	}

	private void Update()
	{
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement = cam.TransformDirection(movement);
        // We need to detach jump movement from the camera angle


        // Detect pressing ESC for pausing
        pausedPressed = Input.GetKey(KeyCode.Escape);
        if ((pausedPressed != oldPausedPressed) && pausedPressed)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
        oldPausedPressed = pausedPressed;

        
        if (Showtime > 0f)
        {
            Showtime = Showtime - (Time.deltaTime);
        }
        else
        {
            speed = 15f;
            if (currentParitcles != null) {
                Destroy(currentParitcles);
            }
        }

        // Changed to only make horizontal movements affect while grounded
        //if (ground)
        //{
        
        //}

        // Jump stuff
        if (Physics.Raycast(transform.position, Vector3.down, raycast))
        {
            ground = true;
        }
        else
        {
            ground = false;
        }

        if (Input.GetKeyDown("space") && ground)
        {
            // TODO: Add ray debug draw to make sure raycasting is in the right direction
            jump = 1.0f;
        }
        else
        {
            jump = 0.0f;
        }
        movement.y = jump * jumpSpeed;
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            if (currentParitcles != null) {
                Destroy(currentParitcles);
            }

            GameObject particles = Instantiate(SpeedParticles, transform.position, transform.rotation);
            particles.transform.parent = transform;
            currentParitcles = particles;

            // Creates another thread that waits 10 seconds then respawns the pick up
            StartCoroutine(TemporarilyDisable(other.gameObject, 10, null));
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

    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    // Temporarily deactivates the specified game object. Do Not call it on the player game object or it will never respawn
    IEnumerator TemporarilyDisable(GameObject obj, int time, Action callback) {
		obj.SetActive(false);
		yield return new WaitForSeconds(time);
		obj.SetActive(true);

        // Potential extra things we may want to do after waiting the specified time
        if (callback != null) {
            callback();
        }
	}
}