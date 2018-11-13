using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {
	Quaternion m_initRot;

	private void Awake() {
		m_initRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.Instance.CheckResetCamera()){
			transform.rotation = m_initRot;
		}
	}
}
