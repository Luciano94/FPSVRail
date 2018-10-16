using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	[SerializeField] Canvas[] m_HUDs;
	Canvas m_pauseMenu;

	private void Awake() {
		m_pauseMenu = GetComponent<Canvas>();
		foreach (Canvas hud in m_HUDs) {
			hud.enabled = true;
		}
		m_pauseMenu.enabled = false;
	}

	void Update() {
		if (Input.GetButtonDown("Submit")) {
			Pause();
		}
	}

	public void Pause() {
		foreach (Canvas hud in m_HUDs) {
			hud.enabled = !hud.isActiveAndEnabled;
		}
		m_pauseMenu.enabled = !m_pauseMenu.isActiveAndEnabled;
		Time.timeScale = (m_pauseMenu.isActiveAndEnabled? 0f : 1f);
	}
}