﻿using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour
{

    public float gravity = -9.8f;


    public void Attract(Rigidbody body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 localUp = body.transform.up;

        // Apply downwards gravity to body
        body.AddForce(gravityUp * gravity);
        // Align bodies up axis with the centre of planet
        body.rotation = Quaternion.FromToRotation(localUp, gravityUp) * body.rotation;
    }

    public void React(Rigidbody body)
    {
        Vector3 reactDir = (transform.position - body.position).normalized;
        GetComponent<Rigidbody>().AddForce(reactDir * gravity);
    }

    public void JumpReact(FirstPersonController body)
    {
        Vector3 jumpDir = (transform.position - body.transform.position).normalized;
        GetComponent<Rigidbody>().AddForce(jumpDir * body.jumpForce);
    }
}