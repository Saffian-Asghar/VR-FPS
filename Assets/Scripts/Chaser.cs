using UnityEngine;
using System.Collections;

// This script will make the red square enemeies follow the player(default) or the target(if specified)


public class Chaser : MonoBehaviour
{

	public float speed = 20.0f;
	public float minDist = 1f;
	public Transform target;

	void Start()
	{
		// if no target specified, assume the player
		if (target == null)
		{

			if (GameObject.FindWithTag("Player") != null)
			{
				target = GameObject.FindWithTag("Player").GetComponent<Transform>();
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (target == null)
			return;

		// face the target
		transform.LookAt(target);

		float distance = Vector3.Distance(transform.position, target.position);
		if (distance > minDist)
			transform.position += transform.forward * speed * Time.deltaTime;
	}

	// Set the target of the chaser
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

}