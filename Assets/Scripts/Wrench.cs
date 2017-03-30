using UnityEngine;
using System.Collections;

public class Wrench : MonoBehaviour 
{
	public GameObject explosion;
	private PlayerHealth gameController;
	private Transform t;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <PlayerHealth> ();
		}

		if (gameControllerObject = null) 
		{
			print ("GameController not found");
		}
		t = transform;
		print ("start"+this.transform.GetChild(0).position);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			Instantiate (explosion, transform.position, transform.rotation);
			//Instantiate (explosion);
			//explosion.transform.position = t.position;
			print ("after" + t.position);
			print ("Collision");
			Destroy (gameObject);
			//Destroy (other.gameObject);
			gameController.AddScore ();
			gameController.GateFall ();

		}
		else 
		{
			return;
		}
	}
}
