using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBall : MonoBehaviour {
    public float speed;
    public float maxSpeed;
    public float minZ;
    public float maxZ;
    Rigidbody baller;
    // Use this for initialization
    void Start()
    {
        baller = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = baller.position;
        Vector3 velocity = baller.velocity;
        if (velocity.z >= 0 && position.z < maxZ)
        {
            if (velocity.z < maxSpeed)
            {
                Vector3 move = new Vector3(0.0f, 0.0f, speed);
                baller.AddForce(move);
            }
        }
        else if (velocity.z > 0 && position.z > maxZ)
        {
            if (velocity.z < maxSpeed)
            {
                Vector3 move = new Vector3(0.0f, 0.0f, -speed);
                baller.AddForce(move);
            }
        }
        else if (velocity.z < 0 && position.z > minZ)
        {
            if (velocity.z < maxSpeed)
            {
                Vector3 move = new Vector3(0.0f, 0.0f, -speed);
                baller.AddForce(move);
            }
        }
        else
        {
            if (velocity.z < maxSpeed)
            {
                Vector3 move = new Vector3(0.0f, 0.0f, speed);
                baller.AddForce(move);
            }
        }

    }
}
