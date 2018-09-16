using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour {
	[SerializeField] private List<GameObject> group;
	private void OnEnable() {
		foreach(GameObject go in group){
			go.GetComponent<StateMachine>().ActivateState(StateMachine.States.CoverState);
		}
	}

	public void TakeDamage(){
		GameObject[] go = group.ToArray();
		if(group.Count > 0){	
			group.RemoveAt(0);
			Destroy(go[0]);
		}else Destroy(gameObject);
	}
}
