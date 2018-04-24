using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomHutGoal : MonoBehaviour {
    public GameObject goal;
    private GameObject[] goalLocs;

	// Use this for initialization
	void Start () {
        goalLocs = GameObject.FindGameObjectsWithTag("HutLocations");
        int randomNum = Random.Range(0, goalLocs.Length - 1);
        Instantiate(goal, goalLocs[randomNum].transform.position, Quaternion.identity);
	}
}
