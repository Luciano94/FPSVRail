using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCover : MonoBehaviour {
	[SerializeField] float m_speed;
	[SerializeField] float m_height = 0.5f;
	Vector3 m_targetPosition;

	private void Update() {
		if (Input.GetButtonDown("Jump")){
			TakeCover();
		}
		m_targetPosition = new Vector3 (transform.position.x,
			m_targetPosition.y,
			transform.position.z);
		transform.position = Vector3.Lerp(transform.position,
			m_targetPosition, Time.deltaTime * m_speed);
	}

	void TakeCover() {
		m_targetPosition = transform.position + Vector3.up * m_height;
			transform.position = Vector3.Lerp(transform.position,
				m_targetPosition, Time.deltaTime * m_speed);
	}
}
