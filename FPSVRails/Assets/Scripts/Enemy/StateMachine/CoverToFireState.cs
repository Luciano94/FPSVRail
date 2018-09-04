using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverToFireState : MonoBehaviour {

	[SerializeField] private Vector3 TargetPosition;
	[SerializeField] private float speed;
	private Vector3 initPos;
	private Vector3 targetPos;
	private float accum;

	// Use this for initialization
	void Awake () {
		initPos = transform.position;
		targetPos = transform.position + TargetPosition;
	}

	private void OnEnable()
	{
		accum = 0.0f;
		initPos = transform.position;
	}

	void FixedUpdate () {
		Vector3 direction = (targetPos - transform.position).normalized;
		accum += speed * Time.deltaTime;

		transform.position = Vector3.Lerp(initPos, targetPos, accum);

		if (accum >= 1.0f)
			GetComponent<StateMachine>().ActivateState(StateMachine.States.FireState);
	}
}
