using UnityEngine;

public class ScreenInput : MonoBehaviour, IInput {
    [SerializeField] VirtualJoystick m_vJoystick;
    bool m_fireButtonState;
    bool m_coverButtonState;

    public bool TakeCover() {
        bool state = m_coverButtonState;
        if (m_coverButtonState) {
            m_coverButtonState = false;
        }
        return state;
    }
    public bool Fire() {
        bool state = m_fireButtonState;
        if (m_fireButtonState) {
            m_fireButtonState = false;
        }
        return state;
    }
    public Vector2 Aim() {
        return Vector2.zero;
    }
    public Vector2 CameraMovement() {
        return m_vJoystick.Direction() / 2.5f;
    }

    public void ActivateFire() {
        m_fireButtonState = true;
    }

    public void ActivateCover() {
        m_coverButtonState = true;
    }

    public bool CheckResetCamera() {
        return false;
    }
}