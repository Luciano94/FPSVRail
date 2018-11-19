using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    private void Update() {
        if (Input.anyKey) {
            SceneManager.LoadScene("Level");
        }
    }

}