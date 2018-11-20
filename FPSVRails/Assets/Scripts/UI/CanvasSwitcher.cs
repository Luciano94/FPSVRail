using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcher : MonoBehaviour {
	[SerializeField] GameObject m_mobileCanvas;
	[SerializeField] GameObject m_VRCanvas;

	public void ToggleVRCanvas (bool state) {
		m_mobileCanvas.SetActive(!state);
		m_VRCanvas.SetActive(state);
	}
}
