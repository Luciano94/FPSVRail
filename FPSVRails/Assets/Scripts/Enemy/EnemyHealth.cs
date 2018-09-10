using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	[SerializeField] private int life;
	
	public void Damage(int amount){
		life--;
		if(life <= 0){
			gameObject.SetActive(false);
		}
	}
}
