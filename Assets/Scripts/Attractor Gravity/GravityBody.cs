using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    public GravityAttractor planet;
    Rigidbody rigidbody;
    FirstPersonController fpc;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        fpc = GetComponent<FirstPersonController>();

        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        // Allow this body to be influenced by planet's gravity
        planet.Attract(rigidbody);
        if (fpc.grounded == true)
        {
            planet.React(rigidbody);
        }
    }
}