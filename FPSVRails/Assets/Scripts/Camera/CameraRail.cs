using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRail : MonoBehaviour {
	[SerializeField] Transform[] m_positions;
	[SerializeField] LevelManager m_levelManager;
	uint m_index = 0;

	public bool GetNextPosition(ref Transform requested) {
		if (m_index < m_positions.Length) {
			requested = m_positions[m_index];
			m_index++;
			return true;
		} else {
			m_levelManager.NextLevel();
			return false;
		}
	}
}