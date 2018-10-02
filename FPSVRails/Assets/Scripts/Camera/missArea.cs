using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missArea : MonoBehaviour {

	[SerializeField] private AudioSource missSound;

	private void OnTriggerEnter(Collider other) {
		missSound.Play();
	}
}