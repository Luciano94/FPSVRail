using UnityEngine;

public class TimeController : MonoBehaviour {

    private void Start() {
        Time.timeScale = 0f;
    }

    public void SetTime(float timeScale) {
        Time.timeScale = timeScale;
    }

}
