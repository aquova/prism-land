using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleTrigger : MonoBehaviour {

	public ParticleSystem particle;
	// Use this for initialization
	void Start () {
		particle.Stop (true);
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Player")) {
			Debug.Log ("MAKES IT INSIDE");
			particle.Play (true);
			//Invoke ("turnoff", .5f);
		}
	}

	//void turnoff()
	//{
	//	particle.Play(false);
	//}
}
