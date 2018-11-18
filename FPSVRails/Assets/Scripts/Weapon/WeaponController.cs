using UnityEngine;
public class WeaponController : MonoBehaviour {
    [SerializeField] LayerMask m_enemiesLayer;
    [SerializeField] float m_radius;
    [SerializeField] int m_damage;
    [SerializeField] float m_sensitivity;
    [SerializeField] CameraCover m_cover;
    Camera m_camera;
    RectTransform m_rect;
    AmmoController ammoController;

    private void Awake() {
        m_rect = GetComponent<RectTransform>();
        m_camera = Camera.main;

        ammoController = AmmoController.Instance;
    }

    private void Update() {
      //  Vector3 delta = InputManager.Instance.Aim();
        if (InputManager.Instance.VR_Mode()) {
           /* Vector3 pos = m_rect.position;
            pos += delta;
            pos.x = Mathf.Clamp(pos.x, 0f, m_halfWitdh * 2);
            pos.y = Mathf.Clamp(pos.y, 0f, m_halfHeigth *2);
            m_rect.position = pos;*/
            //m_rect.position = new Vector2(m_halfWitdh, m_halfHeigth);
            
        } else {
           // m_rect.position = new Vector2(m_halfWitdh, m_halfHeigth);
        }
        Vector3 posToScreen = m_camera.WorldToScreenPoint(m_rect.position);
        Ray ray = m_camera.ScreenPointToRay(posToScreen);

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.magenta);
        if (InputManager.Instance.Fire() && !m_cover.IsCovered()) {
            if (ammoController.shoot()) {
                RaycastHit hit;
                if (Physics.SphereCast(ray.origin, m_radius,
                        ray.direction, out hit, 100f)) {

                    EnemyHealth enemyHealth;
                    if (enemyHealth = hit.transform.GetComponent<EnemyHealth>()) {
                        enemyHealth.Damage(m_damage);
                    }
                }
            }
        }
    }

}