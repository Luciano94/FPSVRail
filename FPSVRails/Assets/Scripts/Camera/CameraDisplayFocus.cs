using UnityEngine;

public class CameraDisplayFocus : MonoBehaviour {
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2f);
    }

}