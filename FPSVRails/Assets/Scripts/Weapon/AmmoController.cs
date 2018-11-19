﻿using System.Collections;
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
	[SerializeField] Image[] ammoImg;
	[SerializeField] AudioSource shootSound;
	[SerializeField] AudioSource reloadSound;
	[SerializeField] AudioSource emptyGun;
	[SerializeField] Image reloadImg;
	private int currentAmmo;

	private void Awake() {
		currentAmmo = maxAmmo;
		foreach (Image img in ammoImg){
			img.enabled = true;
		}
		reloadImg.enabled = false;
	}
	public bool shoot(){
		if(currentAmmo > 0){
			shootSound.Play();
			currentAmmo--;
			ammoImg[currentAmmo].enabled = false;
			return true;
		}
		emptyGun.Play();
		reloadImg.enabled =  true;
		return false;
	}

	public void reload(){
		if(currentAmmo < maxAmmo){
			reloadImg.enabled =  false;
			reloadSound.Play();
			currentAmmo = maxAmmo;
			foreach (Image img in ammoImg){
				img.enabled = true;
			}
		}
	}
}
