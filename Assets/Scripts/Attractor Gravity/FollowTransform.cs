using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    public Transform transfToFollow;

	void FixedUpdate ()
    {
        transform.Translate((transfToFollow.position - transform.position) * Time.deltaTime);
        //transform.position = transfToFollow.position;
    }
}