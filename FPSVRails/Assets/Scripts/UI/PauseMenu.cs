using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	[SerializeField] Canvas m_HUD;
	Canvas m_pauseMenu;

	private void Awake() {
		DontDestroyOnLoad(gameObject);
		m_pauseMenu = GetComponent<Canvas>();
		m_HUD.enabled = true;
		m_pauseMenu.enabled = false;
	}

	void Update () {
		if (Input.GetButtonDown("Submit")) {
			Pause();
		}	
	}

	void Pause() {
		m_HUD.enabled = !m_HUD.isActiveAndEnabled;
		m_pauseMenu.enabled = !m_pauseMenu.isActiveAndEnabled;
		Time.timeScale = (m_pauseMenu.isActiveAndEnabled? 0f : 1f);
	}
}
