using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	[SerializeField] private float speed;
	[SerializeField] private float lifetime = 5f;
	[SerializeField] private AudioSource shootSound;
	[SerializeField] private AudioSource impactSound;
    [SerializeField] private float Rotratio = 5;
	void OnEnable() {
		shootSound.Play();
		Vector3 rndDirection = new Vector3(Random.Range(-Rotratio, Rotratio), Random.Range(-Rotratio, Rotratio), 0);
		transform.Rotate(rndDirection);
        CancelInvoke("Disable");
		Invoke("Disable", lifetime);
	}

	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Level") Disable();
		if (other.tag == "Player" &&
		!other.GetComponent<CameraMovement>().IsMoving())
			impactSound.Play();
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