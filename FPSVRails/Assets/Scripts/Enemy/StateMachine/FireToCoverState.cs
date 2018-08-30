using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireToCoverState : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private Vector3 targetPos;
	private Rigidbody rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		targetPos = transform.position - targetPos;
	}

	void FixedUpdate()
	{
		Vector3 direction = (targetPos - transform.position).normalized;
		rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
		if (transform.position.y <= targetPos.y)
			GetComponent<StateMachine>().ActivateState(StateMachine.States.CoverState);
	}
}
