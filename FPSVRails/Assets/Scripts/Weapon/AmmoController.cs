using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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
	[SerializeField] AudioSource shootSound;
	[SerializeField] AudioSource reloadSound;
	[SerializeField] AudioSource emptyGun;
	[SerializeField] Image reloadImg;
	public UnityEvent BulletConsumed;
	public UnityEvent Reload;
	private int currentAmmo;

	private void Awake() {
		currentAmmo = maxAmmo;
		reloadImg.enabled = false;
	}
	public bool shoot(){
		if(currentAmmo > 0){
			shootSound.Play();
			currentAmmo--;
			BulletConsumed.Invoke();
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
			Reload.Invoke();
		}
	}
}
