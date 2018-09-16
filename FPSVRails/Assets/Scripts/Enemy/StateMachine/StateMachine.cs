using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

	public enum States
	{
		CoverState,
		FireState,
		CoverToFireState,
		FireToCoverState
	}

	[SerializeField] private MonoBehaviour[] MonoStates;
	[SerializeField] private States initState;
	[SerializeField] private MonoBehaviour actualState;

	private void OnEnable() {
		//ActivateState(initState);
	}

	public void ActivateState(States states)
	{
			if (actualState != null)
				actualState.enabled = false;
			actualState = MonoStates[(int)states];
			actualState.enabled = true;
	}
}
