using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotter : MonoBehaviour {

	private EnemyManager eM;

	private void Awake() {
		eM = EnemyManager.Instance;
	}

	void Update () {
		if(Input.GetButtonUp("Fire1")){
			if(eM.ActualGroup != null)
				eM.ActualGroup.GetComponent<EnemyGroup>().TakeDamage();
		}	
	}
}
