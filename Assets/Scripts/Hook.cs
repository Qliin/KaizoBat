using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour 
{
	private Transform targetGrapplePoint;
	private GameObject batman;
	private SpringJoint2D hSpring;

	private bool grappling = false;
	private bool pulling = false;

	void OnEnable () 
	{
		batman = GameObject.FindGameObjectWithTag("Player");
		hSpring = GetComponent<SpringJoint2D>();
		hSpring.connectedBody = batman.GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		if(grappling)
		{
			transform.position = Vector2.Lerp(transform.position, targetGrapplePoint.position, 0.1f);
			return;
		}
		//If Pulling
		Debug.Log("Pulling");
		hSpring.distance = Mathf.Lerp(hSpring.distance, 0, 0.15f);
	}


	void GrappleTo(GameObject grapplePoint)
	{
		targetGrapplePoint = grapplePoint.transform;
		grappling = true;
		grapplePoint.SendMessage("Grappled");
	}

	void OnGrapplePoint(GameObject grapplePoint)
	{
		pulling = true;
		grappling = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(pulling)
			{
				batman.SendMessage("GrappleEnded");
				Destroy(gameObject);
			}
		}
	}
}
