using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleZone : MonoBehaviour 
{	
	private GameObject grapplePoint;

	void Start() 
	{	
		grapplePoint = transform.parent.gameObject;
	}

	void OnTriggerStay2D(Collider2D other) 
	{		
		if(other.gameObject.tag == "Player")
		{
			other.SendMessage("WithinGrappleRange", grapplePoint);
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if(other.gameObject.tag == "Player")
		{
			other.SendMessage("OutOfGrappleRange", grapplePoint);
		}
	}
}
