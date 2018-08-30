using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverToFireState : MonoBehaviour {

	[SerializeField] private Vector3 TargetPosition;
	[SerializeField] private float speed;
	private Vector3 initPos;
	private Vector3 targetPos;
	private Rigidbody rb;

	// Use this for initialization
	void Awake () {
		initPos = transform.position;
		targetPos = transform.position + TargetPosition;
		rb = GetComponent<Rigidbody>();	
	}

	void FixedUpdate () {
		Vector3 direction = (targetPos - transform.position).normalized;
		rb.MovePosition(transform.position+direction*speed*Time.deltaTime);
		if (transform.position.x >= targetPos.x)
			GetComponent<StateMachine>().ActivateState(StateMachine.States.FireState);
	}
}
