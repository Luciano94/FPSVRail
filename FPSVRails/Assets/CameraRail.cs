using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRail : MonoBehaviour {
	[SerializeField] Transform[] m_positions;
	uint m_index = 0;

	public bool GetNextPosition(out Transform requested) {
		requested = m_positions[m_index];
		if (m_index < m_positions.Length){
			m_index++;
			return true;
		} else {
			return false;
		}
	} 
}
