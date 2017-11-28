using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeOrbits : MonoBehaviour {

    public float orbVel;
    public Transform moon;
    public float moonOrbVel;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.AddTorque(0.0f, orbVel, 0.0f);
        //transform.Rotate(0.0f, orbVel, 0.0f);
        moon.Rotate(0.0f, moonOrbVel, 0.0f);
	}
}