using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed;
	//Rigidbody theRigidBody;

	void Start()
	{
		//theRigidBody = GetComponent <Rigidbody> ();
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		//theRigidBody.AddForce (transform.forward * speed);
	}

}
