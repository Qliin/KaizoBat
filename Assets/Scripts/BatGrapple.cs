using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatGrapple : MonoBehaviour 
{
	public GameObject point {get; private set;}
	private BatController bController;
	public GameObject hook;

	void OnEnable()
	{
		point = null;
		bController = GetComponent<BatController>();
	}

	void WithinGrappleRange(GameObject grapplePoint)
	{
		if(BatIsLookingToward(grapplePoint)) 
		{
			point = grapplePoint;
			grapplePoint.SendMessage("Show");
		}
		else 
		{
			if(point == grapplePoint)
			{
				point = null;
			}
			grapplePoint.SendMessage("Hide");
		}
	}

	bool BatIsLookingToward(GameObject grapplePoint) 
	{
		Vector2 pointDirection = grapplePoint.transform.position - this.transform.position;

		if(Mathf.Sign(pointDirection.x) == Mathf.Sign(bController.batDirection.x)) 
		{
			return true;
		}

		return false;
	}

	void OutOfGrappleRange(GameObject grapplePoint)
	{
		if(point == grapplePoint)
		{
			point = null;
		}
		grapplePoint.SendMessage("Hide");
	}

	public bool Shoot()
	{
		if(point != null)
		{
			GameObject hook_Ins = Instantiate(hook, transform.position, transform.rotation) as GameObject;
			hook_Ins.SendMessage("GrappleTo", point);
			return true;
		}

		return false;
	}
}
