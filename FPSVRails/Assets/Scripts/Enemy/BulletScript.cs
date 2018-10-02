using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	[SerializeField] private float speed;
	[SerializeField] private float lifetime = 5f;
	[SerializeField] private AudioSource shootSound;
	[SerializeField] private AudioSource impactSound;
	void Start() {
		shootSound.Play();
		Vector3 rndDirection = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
		transform.Rotate(rndDirection);
		Invoke("Disable", lifetime);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")impactSound.Play();
		Invoke("Disable", 0.5f);
	}

	// Update is called once per frame
	void Update() {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

	void Disable() {
		gameObject.SetActive(false);
	}
}