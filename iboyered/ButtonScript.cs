using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

	// Set this maxHeight to however high you want the door to go
	public float doorMaxHeight;
	// Set this gameobject to the door itself to move up
	public GameObject Door;
	public bool doorIsOpening;
	Material m_Material;

	// Use this for initialization
	void Start () {
		m_Material = GetComponent<Renderer>().material;
		m_Material.color = Color.red;
		doorIsOpening = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (doorIsOpening == true) {
			Door.transform.Translate (Vector3.up * Time.deltaTime * 5);
			m_Material.color = Color.green;
		}
		// Stop the door if it gets too high
		if (Door.transform.position.y > doorMaxHeight) {
			doorIsOpening = false;
			m_Material.color = Color.red;
		}
	}

	// If the ball collides with this part of the button
	void OnTriggerEnter (Collider other) {
		// Rename this to whoever 
		if( other.gameObject.name.Equals("Player") == true ) {
			doorIsOpening = true;
			m_Material.color = Color.green;
		}
	}
}
