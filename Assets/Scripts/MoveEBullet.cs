using UnityEngine;
using System.Collections;

public class MoveEBullet : MonoBehaviour
{
	public float speed;
	public Transform target;

	void Start()
	{
		//Quaternion rotation = Quaternion.LookRotation (target.position - transform.position);
		//transform. rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime);

		transform.Translate (Vector3.forward *speed * Time.deltaTime);
	}
}
