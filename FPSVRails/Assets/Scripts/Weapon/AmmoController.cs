using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoController : MonoBehaviour {

	private static AmmoController instance;
	public static AmmoController Instance{
		get{
			instance = FindObjectOfType<AmmoController>();
			if(instance == null){
				GameObject go = new GameObject("AmmoController");
				instance = go.AddComponent<AmmoController>();
			}
			return instance;
		}
	}

	[SerializeField] private int maxAmmo;
	[SerializeField] Text ammoTxt;
	private int currentAmmo;
	InputManager inputManager;

	private void Awake() {
		inputManager = InputManager.Instance;
		currentAmmo = maxAmmo;
		ammoTxt.text = 	currentAmmo + " / "+ maxAmmo;
	}
	public bool shoot(){
		if(currentAmmo > 0){
			currentAmmo--;
			ammoTxt.text = currentAmmo + " / "+ maxAmmo;
			return true;
		}
		return false;
	}

	public void reload(){
		currentAmmo = maxAmmo;
		ammoTxt.text = currentAmmo + " / "+ maxAmmo;
	}
}
