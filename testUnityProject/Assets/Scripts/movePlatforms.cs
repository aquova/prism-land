using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatforms : MonoBehaviour {
    public int minY;
    public int maxY;
    public int speed;
    public int offset;
    private float startY;

	// Use this for initialization
	void Start () {
        startY = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y - startY <= minY) {
            speed = -speed;
        } else if (gameObject.transform.position.y - startY >= maxY) {
            speed = -speed;
        }

        Vector3 velocity = new Vector3(0.0f, speed, 0.0f);
        gameObject.transform.position += velocity * Time.fixedDeltaTime *offset;
	}
}
