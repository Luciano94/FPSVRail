﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour {

	[SerializeField] private int health = 3;
	[SerializeField] private Text healthTxt;

	private void Awake() {
		healthTxt.text = "Health: " + health.ToString();
	}

	private void OnTriggerEnter(Collider other) {
		if(other.tag != "EneTrigger"){	
			if(health > 1){
				health--;
				healthTxt.text = "Health: " + health.ToString(); 
			}
			else{
				SceneManager.LoadScene("End");
			}
		}
	}
}
