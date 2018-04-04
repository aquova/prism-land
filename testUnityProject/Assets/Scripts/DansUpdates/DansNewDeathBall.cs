using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DansNewDeathBall : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public float minZ;
    public float maxZ;
    public float minX;
    public float maxX;
    Rigidbody baller;
    // Use this for initialization
    void Start()
    {
        baller = GetComponent<Rigidbody>();
        baller.velocity = new Vector3(speed, speed, speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = baller.position;
        Vector3 velocity = baller.velocity;

        //y movement

        if (velocity.z >= 0 && position.z < maxZ)
        {
            baller.velocity = new Vector3(0.0f, 0.0f, -speed);
        }
        else if (velocity.z > 0 && position.z > maxZ)
        {
            baller.velocity = new Vector3(0.0f, 0.0f, speed);
        }
        else if (velocity.z < 0 && position.z > minZ)
        {

            baller.velocity = new Vector3(0.0f, 0.0f, speed);
        }
        else
        {
            baller.velocity = new Vector3(0.0f, 0.0f, -speed);
        }

        // X movement
        if (velocity.x >= 0 && position.x < maxX)
        {
            baller.velocity.Set(-speed, -speed, 0.0f);
        }
        else if (velocity.x >= 0 && position.x > maxX)
        {
            baller.velocity.Set(speed, speed, 0.0f);
        }
        else if (velocity.x < 0 && position.x > minX)
        {

            baller.velocity.Set(speed, speed, 0.0f);
        }
        else
        {
            baller.velocity.Set(-speed, -speed, 0.0f);
        }

    }
}
