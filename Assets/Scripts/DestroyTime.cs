using UnityEngine;
using System.Collections;

public class DestroyTime : MonoBehaviour 
{
	public float killTime;

	void Start()
	{
			Destroy (gameObject,killTime);
	}
}
