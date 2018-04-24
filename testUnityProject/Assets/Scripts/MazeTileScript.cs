using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTileScript : MonoBehaviour {

    public Material touchedMaterial;

	private void OnCollisionEnter(Collision collision)
	{
        gameObject.GetComponent<Renderer>().material = touchedMaterial;
	}
}
