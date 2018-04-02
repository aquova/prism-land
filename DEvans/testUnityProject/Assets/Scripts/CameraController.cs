using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Modifying so we don't have zoom ability
[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 7.0f;
    public float resetDistance = 7.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    // Modifying camera script to keep distance locked, but zoom in
    // if an object comes between the camera and the ball

    private Rigidbody rigidbody;

    float x = 0.0f;
    float y = 0.0f;

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    void LateUpdate()
    {
        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distance, distance);

            RaycastHit hit;
            // Attempting to make the raycast out to the camera
            RaycastHit fullHit;
            // Linecast between the target (ball) and the camera
            Physics.Linecast(target.position, transform.position, out fullHit);
            // If the full hit is less than 7, set the position appropriately
            if (fullHit.distance < 7.0)
                if (Physics.Linecast(target.position, transform.position, out hit))
                {
                    distance = hit.distance;
                }
                else
                {
                    distance = resetDistance;
                }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
