using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatInput : MonoBehaviour {

	public bool jump{ get; private set; }
	public float horizontal{ get; private set; }
	public bool glide{ get; private set; }
	public bool grapple { get; private set; }

	void Update ()
	{
		jump = Input.GetKeyDown (KeyCode.W);
		glide = Input.GetKey (KeyCode.W);
		horizontal = Input.GetAxis ("Horizontal");
		grapple = Input.GetKeyDown (KeyCode.E);
	}
}
