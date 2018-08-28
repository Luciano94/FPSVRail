using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRail : MonoBehaviour {
	[SerializeField] Transform[] m_positions;
	uint m_index = 0;

	private void Awake() {

	}

	public bool GetNextPosition(out Transform requested) {
		if (m_index < m_positions.Length) {
			requested = m_positions[m_index];
			m_index++;
			return true;
		} else {
			requested = m_positions[0];
			print("Nos pasamos");
			return false;
		}
	}
}