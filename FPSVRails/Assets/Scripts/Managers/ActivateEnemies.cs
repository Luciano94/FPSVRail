using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour {

	private EnemyManager eManager;

	// Use this for initialization
	void Awake() {
		eManager = EnemyManager.Instance;
	}

	private void OnTriggerEnter(Collider other) {
		eManager.ActiveGroup();
		Destroy(gameObject);
	}
}