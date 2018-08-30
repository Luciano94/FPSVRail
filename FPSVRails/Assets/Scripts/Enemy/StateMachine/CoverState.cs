using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverState : MonoBehaviour {

	[SerializeField] private float minTime;
	[SerializeField] private float maxTime;
	private float time;
	private float currentTime;

	private void OnEnable() {
		time = Random.Range(minTime, maxTime);
		currentTime = 0;
	}

	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime > time)
			GetComponent<StateMachine>().ActivateState(StateMachine.States.CoverToFireState);
	}
}
