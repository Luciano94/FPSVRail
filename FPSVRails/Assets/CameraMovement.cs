using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	[SerializeField] CameraRail m_cameraRail;
	Camera m_camera;
	Transform nextPos;
	float m_speed = 1f;

	private void Awake() {
		m_camera = Camera.main;
	}
	void Update () {
		if(Input.GetButton("Fire1")) {
			m_cameraRail.GetNextPosition(out nextPos);
		}
		if (transform.position != nextPos.position) {

		}
	}
}
