using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	[SerializeField] CameraRail m_cameraRail;
	[SerializeField] float m_speed = 1f;
	Camera m_camera;
	Transform nextPos;

	private void Awake() {
		m_camera = Camera.main;
	}
	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			m_cameraRail.GetNextPosition(out nextPos);
		}
		if (nextPos != null) {
			if (transform.position != nextPos.position) {
				// Vector3 diff = nextPos.position - transform.position;
				// transform.position += diff * m_speed;
				float distance = Vector3.Distance(transform.position, nextPos.position);
				float delta = Time.deltaTime * (m_speed / distance);
				transform.position = Vector3.Lerp(transform.position,
					nextPos.position, delta);
				transform.rotation = Quaternion.Lerp(transform.rotation,
					nextPos.rotation, delta);
			}
		}
	}
}