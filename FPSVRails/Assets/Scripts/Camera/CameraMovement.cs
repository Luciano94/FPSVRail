using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	[SerializeField] CameraRail m_cameraRail;
	[SerializeField] float m_speed = 1f;
	Transform nextPos;
	bool m_moving;

	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			m_cameraRail.GetNextPosition(out nextPos);
			m_moving = true;
		}
		if (nextPos != null && m_moving) {
			if (transform.position != nextPos.position) {
				float distance = Vector3.Distance(transform.position, nextPos.position);
				float delta = Time.deltaTime * (m_speed / distance);
				transform.position = Vector3.Lerp(transform.position,
					nextPos.position, delta);
				transform.rotation = Quaternion.Lerp(transform.rotation,
					nextPos.rotation, delta);
			} else {
				m_moving = false;
			}
		}
	}

	public bool IsMoving() {
		return m_moving;
	}

}