using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
	public GameObject FieldSource;
	public int initialImpulse;
	private const float G = 0.0667408f; //Constante de gravitacão = 6,67408*10^-11, não é necessário aqui, utilizada apenas para consistência com a Física

    //Variáveis das funções para mover a lua em runtime
    private Vector3 screenPoint;
	private Vector3 offset;

	//Adiciona um impulso tangente inicial apenas para não cair diretamente no planeta
	void Start()
	{
		var tangent = new Vector3 (1 * initialImpulse, 0, 0);
		gameObject.GetComponent<Rigidbody> ().AddForce(tangent, ForceMode.Impulse);
	}
	
	//Aplica a força da gravidade
	void Update()
	{
		gameObject.GetComponent<Rigidbody> ().AddForce(GravityVector(), ForceMode.Force);
		Debug.DrawLine (gameObject.transform.position, GravityVector(), Color.red);
	}

	Vector3 GravityVector()
	{
		//Variáveis para organização do cálculo
		var m = gameObject.GetComponent<Rigidbody> ().mass;
		var M = FieldSource.GetComponent<Rigidbody> ().mass;
		var p = gameObject.transform.position;
		var P = FieldSource.transform.position;

		//https://en.wikipedia.org/wiki/Center_of_mass
		var centerOfMass = (1/(m+M))*((m*p)+(M*P));

		//Vetor que aponta sempre para o centro de massa do sistema
		var radialDirection = centerOfMass - gameObject.transform.position;

		//https://pt.wikipedia.org/wiki/Constante_gravitacional_universal
		var intensity = (G * m * M) / Mathf.Pow (radialDirection.magnitude, 2);

		return radialDirection.normalized*intensity;
	}

	//Funções para mover a lua em runtime
	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag()
	{
		Vector3 cursorPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint (cursorPoint) + offset;
		transform.position = cursorPosition;
	}
}