using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRollingScript : MonoBehaviour {
    private Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    private bool ground;
    public float raycast;
    public float jump;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        CharacterController controller = GetComponent<CharacterController>();

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
        Vector3 movement = new Vector3(moveHorizontal, jump * jumpSpeed, moveVertical);
        // Only update speed if on the ground
        if (ground)
        {
            rb.AddForce(movement * speed);
        }
    }
}
