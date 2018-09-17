using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		PlayerLife player = other.GetComponent<PlayerLife>();
		if(player != null)
			player.TakeDamage();
	}
}
