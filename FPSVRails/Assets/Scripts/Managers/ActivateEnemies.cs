using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour {

	private EnemyManager eManager;

	// Use this for initialization
	void Start () {
		eManager = EnemyManager.Instance;
	}
	
	private void OnTriggerEnter(Collider other){
		Destroy(other.gameObject);
		other = null;
		if(other == null)
			eManager.ActiveGroup();
	}
}
