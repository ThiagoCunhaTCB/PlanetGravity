using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class travel : MonoBehaviour
{
	public int initialImpulse;

	void Start()
	{
		var forceVector = new Vector3 (0, initialImpulse, 0);
		gameObject.GetComponent<Rigidbody> ().AddForce(forceVector, ForceMode.Impulse);
	}
}