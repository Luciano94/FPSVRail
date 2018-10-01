using UnityEngine;

[RequireComponent(typeof(VRInput))]
[RequireComponent(typeof(ScreenInput))]
public class InputManager : MonoBehaviour, IInput {
    [SerializeField] bool m_VRmode = false;
    [SerializeField] GameObject ScreenInputCanvas;
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
    private void Awake() {
        if (m_VRmode) {
            m_input = GetComponent<VRInput>();
            ScreenInputCanvas.SetActive(false);
        } else {
            m_input = GetComponent<ScreenInput>();
            ScreenInputCanvas.SetActive(true);
        }
    }

    public Vector2 Aim() {
        return m_input.Aim();
    }

    public Vector2 CameraMovement() {
        return m_input.CameraMovement();
    }

    public bool Fire() {
        return m_input.Fire();
    }

    public bool TakeCover() {
        return m_input.TakeCover();
    }

    public bool CheckResetCamera() {
        return m_input.CheckResetCamera();
    }

    public bool VR_Mode() {
        return m_VRmode;
    }

    public void SwitchMode() {
        if (m_VRmode) {
            m_input = GetComponent<ScreenInput>();
            ScreenInputCanvas.SetActive(true);
            m_VRmode = false;
        } else {
            m_input = GetComponent<VRInput>();
            ScreenInputCanvas.SetActive(false);
            m_VRmode = true;
        }
    }

}