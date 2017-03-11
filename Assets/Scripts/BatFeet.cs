using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatFeet : MonoBehaviour 
{
	private GameObject batman;

	public bool isGrounded { get; set;}

	void Start () 
	{
		batman = transform.parent.gameObject;
	}

	//Touched ground
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "ground" || other.gameObject.tag == "building")
		{
			isGrounded = true;
		}
	}

	//Is touching ground
	void OnTriggerStay2D(Collider2D other) 
	{
		if(other.gameObject.tag == "ground" || other.gameObject.tag == "building")
		{
			isGrounded = true;
		}
	}

	//Stopped touching ground
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "ground" || other.gameObject.tag == "building")
		{
			isGrounded = false;
		}	
	}
}
