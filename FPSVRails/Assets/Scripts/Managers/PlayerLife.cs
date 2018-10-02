using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

	[SerializeField] private int health = 3;
	[SerializeField] private Text healthTxt;
	public UnityEvent damageTaken;

	private void Awake() {
		healthTxt.text = "Health: " + health.ToString();
	}

	public void TakeDamage() {
		if (health > 1) {
			health--;
			healthTxt.text = "Health: " + health.ToString();
			damageTaken.Invoke();
			Handheld.Vibrate();
		}
		else{
			SceneManager.LoadScene("End");
		}
	}
}