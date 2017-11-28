using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitVelocity : MonoBehaviour
{
    public Rigidbody orbitObj;
    public bool retrograde = false;
    public float boost = 1; //TODO: Calculate adicional boost

    private Rigidbody rb;
    private float orbitVelocity;

    const float G = 66.7408f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        Vector3 direction = orbitObj.position - rb.position;
        float distance = direction.magnitude;
        float forceMagnitude = G * (rb.mass * orbitObj.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;


        // escape velocity
        // Mathf.Pow((G * M / d), 0.5f)
        //escapeVelocity = Mathf.Pow((G * orbitObj.mass / distance), 0.5f);

        // Orbital velocity
        // Mathf.Pow(d * g, 0.5f)
        orbitVelocity = Mathf.Pow(distance * forceMagnitude, 0.5f);

        Debug.Log("forceMagnitude: " + forceMagnitude);

        Vector3 tangent;
        if (retrograde)
            tangent = new Vector3(1 * orbitVelocity * boost, 0, 0);
        else
            tangent = new Vector3(-1 * orbitVelocity * boost, 0, 0);
        rb.AddForce(tangent, ForceMode.Impulse);
    }
}