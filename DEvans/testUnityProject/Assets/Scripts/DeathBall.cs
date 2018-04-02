using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBall : MonoBehaviour {
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = baller.position;
        Vector3 velocity = baller.velocity;
        float speedZ = moveBall(velocity.z, position.z, minZ, maxZ);
        float speedX = moveBall(velocity.x, position.x, minX, maxX);
        baller.AddForce(new Vector3(speedX, 0, speedZ));
        
    }
    float moveBall(float velocity, float position, float min, float max)
    {
        if (velocity >= 0 && position < max)
        {
            if (velocity < maxSpeed)
            {
                return speed;
            }
        }
        else if (velocity > 0 && position > max)
        {
            if (velocity < maxSpeed)
            {
                return -speed;
            }
        }
        else if (velocity < 0 && position > min)
        {
            if (velocity < maxSpeed)
            {
                return -speed;
            }
        }
        else
        {
            if (velocity < maxSpeed)
            {
                return speed;
            }
        }
        return 0;
    }
}
