using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePoint : MonoBehaviour 
{
	private SpriteRenderer gRenderer;
	private bool isGrappled;

	void OnEnable()
	{
		gRenderer = GetComponentInChildren<SpriteRenderer>();
		isGrappled = false;
	}

	void Start()
	{
		gRenderer.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		other.gameObject.SendMessage("OnGrapplePoint", this.gameObject);
	}

	void Show() 
	{
		gRenderer.enabled = true;
	}

	void Hide() 
	{
		gRenderer.enabled = false;
	}

	void Grappled()
	{
		isGrappled = true;
	}
}
