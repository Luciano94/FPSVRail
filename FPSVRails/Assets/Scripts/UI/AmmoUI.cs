using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour {
	Image[] m_bulletImages;

	private void Awake() {
		m_bulletImages = GetComponentsInChildren<Image>();
		AmmoController.Instance.BulletConsumed.AddListener(BulletConsumed);
		AmmoController.Instance.Reload.AddListener(Reload);
	}

	void BulletConsumed() {
		foreach (Image img in m_bulletImages) {
			if (img.enabled) {
				img.enabled = false;
				break;
			}
		}
	}

	void Reload() {
		foreach (Image img in m_bulletImages) {
			img.enabled = true;
		}
	}
}
