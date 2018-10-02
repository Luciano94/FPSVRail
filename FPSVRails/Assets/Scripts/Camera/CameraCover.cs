using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCover : MonoBehaviour {
	[SerializeField] float m_speed;
	[SerializeField] float m_height = 0.5f;
	CameraMovement m_camMovement;
	Vector3 m_targetPosition;
	bool m_covered;
	AmmoController ammoController;

	private void Start() {
		m_camMovement = GetComponent<CameraMovement>();
		m_targetPosition = transform.position;
		m_covered = false;
		ammoController = AmmoController.Instance;
	}

	private void LateUpdate() {
		if (!m_camMovement.IsMoving()) {
			if (InputManager.Instance.TakeCover()) {
				TakeCover();
				ammoController.reload();
			}
			transform.position = Vector3.Lerp(transform.position,
				m_targetPosition, Time.deltaTime * m_speed);
		} else {
			m_targetPosition = transform.position;
		}
	}

	void TakeCover() {
		m_targetPosition = transform.position +
			Vector3.up * m_height * (m_covered? 1f: -1f);
		m_covered = !m_covered;
	}
}