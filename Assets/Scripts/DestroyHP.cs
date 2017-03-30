using UnityEngine;
using System.Collections;

public class DestroyHP : MonoBehaviour 
{
		//public GameObject explosion;
		private PlayerHealth gameController;

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
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.tag == "Player") 
			{
				//Instantiate (explosion, transform.position, transform.rotation);
				print ("Health");
				Destroy (gameObject);
			    gameController.AddHealth ();

			}
			else 
			{
				return;
			}
		}
}


