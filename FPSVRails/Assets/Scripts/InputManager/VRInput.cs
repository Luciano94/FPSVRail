using UnityEngine;

public class VRInput : MonoBehaviour, IInput {
    bool m_hasGyro;
    Gyroscope m_gyro;
    float m_screenHeight;

    private void Awake() {
        m_hasGyro = SystemInfo.supportsGyroscope;
        if (m_hasGyro) {
            m_gyro = Input.gyro;
            m_gyro.enabled = true;
        }
    }

    public bool TakeCover() {
        return Input.GetButtonDown("Cover");
    }
    public bool Fire() {
        return Input.GetButtonDown("Fire");
    }

    public Vector2 Aim() {
        Vector2 aim = new Vector2(
            Input.GetAxis("AimX"), -Input.GetAxis("AimY")
        );
        return aim * 6f;
    }

    public Vector2 CameraMovement() {
        Vector2 diff;
        if (m_hasGyro) {
            diff.x = -m_gyro.rotationRate.y;
            diff.y = m_gyro.rotationRate.x;
        } else {
            diff.x = Input.acceleration.x * 2f;
            diff.y = Input.acceleration.z * 2f;
        }
        return diff;
    }

    public bool CheckResetCamera() {
        return Input.GetButtonDown("Reset Camera");
    }
}