using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private bool isColliding = false;
	private GameObject collidingGameObj;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (isColliding)
			{
				collidingGameObj.GetComponent<Interactable>();
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		isColliding = true;
		collidingGameObj = other.gameObject;
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		isColliding = false;
		collidingGameObj = null;
	}
}
