using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireToCoverState : MonoBehaviour {

	[SerializeField] private float speed;
	private Vector3 targetPos;
	private float accum = 0.0f;
	private Vector3 srcPos;

	void Awake()
	{
        targetPos = transform.position;
	}

	private void OnEnable()
	{
		accum = 0.0f;
		srcPos = transform.position;
	}

	void FixedUpdate()
	{
        Vector3 direction = (targetPos - transform.position).normalized;
		accum += speed * Time.deltaTime;
		
		transform.position = Vector3.Lerp(srcPos, targetPos, Mathf.Clamp01(accum));

        if (accum >= 1.0f)
            GetComponent<StateMachine>().ActivateState(StateMachine.States.CoverState);
	}
}
