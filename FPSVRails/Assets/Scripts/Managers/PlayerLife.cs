using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

	[SerializeField] private int health = 3;
	[SerializeField] private Image[] healthImg;
	public UnityEvent damageTaken;
	private CameraMovement cameraMovement;

	private void Awake() {	
		foreach(Image img in healthImg){
			img.enabled = true;
		}
		cameraMovement = GetComponent<CameraMovement>();
	}

	public void TakeDamage() {
		if(!cameraMovement.IsMoving())	
			if (health > 1) {
				health--;
				healthImg[health].enabled = false;
				damageTaken.Invoke();
				Handheld.Vibrate();
			}
			else{
				SceneManager.LoadScene("End");
			}
	}
}