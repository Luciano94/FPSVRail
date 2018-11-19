using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(VRInput))]
[RequireComponent(typeof(ScreenInput))]
public class InputManager : MonoBehaviour, IInput {
    [SerializeField] GameObject m_screenInputCanvas;
    [SerializeField] CameraMovement m_cameraMovement;
    [SerializeField] bool m_VRmode = false;
    IInput m_input;
    static InputManager m_instance;

    public static InputManager Instance {
        get {
            m_instance = FindObjectOfType<InputManager>();
            if (m_instance == null) {
                GameObject go = new GameObject("InputManager");
                m_instance = go.AddComponent<InputManager>();
            }
            return m_instance;
        }
    }

    public bool VRmode{
        get{return m_VRmode;}
    }
    private void Awake() {
        if (m_VRmode) {
            m_input = GetComponent<VRInput>();
            m_screenInputCanvas.SetActive(false);
        } else {
            m_input = GetComponent<ScreenInput>();
            m_screenInputCanvas.SetActive(true);
        }
    }

    public Vector2 Aim() {
        return m_input.Aim();
    }

    public Vector2 CameraMovement() {
        return m_input.CameraMovement();
    }

    public bool Fire() {
        if (m_cameraMovement.IsMoving()) {
            return false;
        } else {
            return m_input.Fire();
        }
    }

    public bool TakeCover() {
        if (m_cameraMovement.IsMoving()) {
            return false;
        } else {
            return m_input.TakeCover();
        }
    }

    public bool CheckResetCamera() {
        return m_input.CheckResetCamera();
    }

    public void SetVR(bool state) {
        m_VRmode = state;
    }

    public void SwitchMode() {
        if (m_VRmode) {
            m_input = GetComponent<ScreenInput>();
            m_screenInputCanvas.SetActive(true);
            m_VRmode = false;
        } else {
            m_input = GetComponent<VRInput>();
            m_screenInputCanvas.SetActive(false);
            m_VRmode = true;
        }
    }

}