using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

	[SerializeField] private int health = 3;
	public UnityEvent damageTaken;
	private CameraMovement cameraMovement;

	private static PlayerLife instance;
	public static PlayerLife Instance{
		get{
			instance = FindObjectOfType<PlayerLife>();
			if(instance == null){
				GameObject go = new GameObject("PlayerLife");
				instance = go.AddComponent<PlayerLife>();
			}
			return instance;
		}
	}

	private void Awake() {	
		cameraMovement = GetComponent<CameraMovement>();
	}

	public void TakeDamage() {
		if(!cameraMovement.IsMoving())	
			if (health > 1) {
				health--;
				damageTaken.Invoke();
				Handheld.Vibrate();
			}
			else{
				SceneManager.LoadScene("End");
			}
	}
}