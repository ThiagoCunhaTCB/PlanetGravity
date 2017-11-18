using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float shipSpeed;
    Rigidbody rb;

	// Use this for initialization
	void Awake ()
    {
        rb = transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        if (inputX != 0)
            rb.AddRelativeForce(inputX * shipSpeed * Time.deltaTime, 0, 0);

        float inputY = Input.GetAxisRaw("Vertical");
        if (inputY != 0)
            rb.AddRelativeForce(0, 0, inputY * shipSpeed * Time.deltaTime);
    }
}
