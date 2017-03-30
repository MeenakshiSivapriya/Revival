using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public float fpsDistance;
	public float viewDistance;
	public float fireDistance;
	public float speed;
	public float damping;
	public float stopDistance;

	public GameObject shot;
	public Transform shotspawn;
	public float fireRate;
	private float nextFire;
	public Animation anim2;
	//public AnimationClip ar;
	//public AnimationClip idle;


	public Transform fpsTarget;
	Rigidbody theRigidBody;
	Renderer enemyRenderer;
	NavMeshAgent agent;

	void Start () 
	{
		agent = GetComponent <NavMeshAgent> ();
		nextFire = 0.0f;
		theRigidBody = GetComponent <Rigidbody> ();
		enemyRenderer = GetComponent <Renderer> ();
		anim2 = GetComponent <Animation> ();
	}

	void Update()
	{
		agent.SetDestination (fpsTarget.position);
		anim2.Play (anim2.GetClip ("Idle").name);
	}

	void FixedUpdate () 
	{
		fpsDistance = Vector3.Distance (fpsTarget.position, transform.position);

		if (fpsDistance > viewDistance) 
		{
			stop ();
		}

		if (fpsDistance < viewDistance) 
		{
			follow ();
			attack ();
			print ("Player Detected!");
			anim2.Play (anim2.GetClip("ar").name);
		}

		if (fpsDistance < fireDistance) 
		{
			fire ();
			print ("ATTACK!");
		}
		//anim2.Play(anim2.GetClip("ar").name);


		if (fpsDistance <= stopDistance) 
		{
			print ("Stop");
			//print (theRigidBody.velocity);
			stop2 ();
			fire ();
		}


	}

	void follow()
	{
		Quaternion rotation = Quaternion.LookRotation (fpsTarget.position - transform.position);
		transform. rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
		//anim2.Play (anim2.GetClip ("ar").name);
	}

	void attack()
	{
		print ("Move");
		anim2.Play (anim2.GetClip("ar").name);
		gameObject.GetComponent<NavMeshAgent> ().enabled = true;
	  
	}

	void fire()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotspawn.position, shotspawn.rotation);
			//Destroy (shot, 2f);
			GetComponent<AudioSource>().Play();
		}
	}

	void stop()
	{
		theRigidBody.velocity = Vector3.zero;
		theRigidBody.angularVelocity = Vector3.zero;
		//anim2.Stop (anim2.GetClip ("ar").name);
		anim2.Play (anim2.GetClip ("Idle").name);
		gameObject.GetComponent <NavMeshAgent> ().enabled = false;
	}

	void stop2()
	{
		theRigidBody.velocity = Vector3.zero;
		theRigidBody.angularVelocity = Vector3.zero;
		anim2.Play (anim2.GetClip ("ar").name);
		gameObject.GetComponent <NavMeshAgent> ().enabled = false;
	}
}
