using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour {
	Image[] m_lifeImages;

	private void Awake() {
		m_lifeImages = GetComponentsInChildren<Image>();
		PlayerLife.Instance.damageTaken.AddListener(DamageTaken);
	}
	
	void DamageTaken() {
		foreach (Image img in m_lifeImages) {
			if (img.enabled) {
				img.enabled = false;
				break;
			}
		}
	}

}
