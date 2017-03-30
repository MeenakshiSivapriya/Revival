using UnityEngine;
using System.Collections;

public class Friend : MonoBehaviour
{
	private PlayerHealth gameController;
	public Transform fpsTarget;
	public float damping;
	public float fpsDistance;
	public float viewDistance;

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

	void FixedUpdate()
	{
		fpsDistance = Vector3.Distance (fpsTarget.position, transform.position);
		if (fpsDistance < viewDistance) 
		{
			Quaternion rotation = Quaternion.LookRotation (fpsTarget.position - transform.position);
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*damping);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
				print ("Found");
				gameController.GameWin();
		}
	}
}
