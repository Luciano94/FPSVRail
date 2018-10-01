using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	[SerializeField] CameraRail m_cameraRail;
	[SerializeField] float m_speed = 1f;
	GeneralMovement m_movement;
	Transform nextPos;
	bool m_moving;

	private void Awake() {
		m_movement = GetComponent<GeneralMovement>();
		m_movement.enabled = false;
	}

	private void Start() {
		NextArea();
		transform.position = nextPos.position;
		transform.rotation = nextPos.rotation;
	}

	void Update() {
		if (nextPos != null && m_moving) {
			if (transform.position != nextPos.position) {
				float distance = Vector3.Distance(transform.position, nextPos.position);
				float delta = Time.deltaTime * (m_speed / distance);
				transform.position = Vector3.Lerp(transform.position,
					nextPos.position, delta);
				transform.rotation = Quaternion.Lerp(transform.rotation,
					nextPos.rotation, delta);
			} else {
				m_movement.enabled = true;
				m_moving = false;
			}
		}
	}

	[ContextMenu("NextArea")]
	public void NextArea() {
		m_cameraRail.GetNextPosition(ref nextPos);
		m_movement.enabled = false;
		m_moving = true;
	}

	public bool IsMoving() {
		return m_moving;
	}

}