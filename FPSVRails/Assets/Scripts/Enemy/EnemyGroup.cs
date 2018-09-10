using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour {
	[SerializeField] private List<GameObject> group;

	private void OnDisable() {
		/*foreach(GameObject go in group){
			go.GetComponent<StateMachine>().enabled = false;
		}*/
	}

	private void OnEnable() {
		foreach(GameObject go in group){
			go.GetComponent<StateMachine>().ActivateState(StateMachine.States.CoverState);
		}
	}
}
