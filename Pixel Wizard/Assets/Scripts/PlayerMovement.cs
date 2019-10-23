using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float moveSpeed = 1f;
	public Rigidbody2D _rigidbody;
	public Animator _animator;
	public Vector2 _movement;

	void Start()
	{
		_rigidbody = gameObject.GetComponent<Rigidbody2D>();
		_animator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_movement.x = Input.GetAxisRaw("Horizontal");
		_movement.y = Input.GetAxisRaw("Vertical");


		if (_movement != Vector2.zero)
		{
			_animator.SetFloat("Horizontal", _movement.x);
			_animator.SetFloat("Vertical", _movement.y);
			Player.Instance.facingdirection = _movement;
		}
		_animator.SetFloat("Speed", _movement.sqrMagnitude);
		
	}

	void FixedUpdate()
	{
		_rigidbody.MovePosition(_rigidbody.position + _movement * moveSpeed * Time.fixedDeltaTime);
	}

}
