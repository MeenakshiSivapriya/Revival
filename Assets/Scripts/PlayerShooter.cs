using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooter : MonoBehaviour
{
	public Transform shotSpawn;
	public GameObject shot;
	public float fireRate;
	private float nextFire;

	void Start()
	{
		nextFire = 0.0f;

	}

	void Update()
	{
	}

	void FixedUpdate()
	{
		if (CrossPlatformInputManager.GetButton("Shoot") && Time.time > nextFire) 
		{
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			nextFire = fireRate + Time.time;
			GetComponent<AudioSource> ().Play ();
		}
	}
}