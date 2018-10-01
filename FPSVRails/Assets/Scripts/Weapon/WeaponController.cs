using UnityEngine;
public class WeaponController : MonoBehaviour {
    [SerializeField] LayerMask m_enemiesLayer;
    [SerializeField] float m_radius;
    [SerializeField] int m_damage;
    [SerializeField] Camera m_camera;
    [SerializeField] float m_sensitivity;
    RectTransform m_rect;
    float m_halfWitdh;
    float m_halfHeigth;

    private void Awake() {
        m_rect = GetComponent<RectTransform>();
        m_halfWitdh = Screen.width * .5f;
        m_halfHeigth = Screen.height * .5f;
    }

    private void Update() {
        Vector2 delta = InputManager.Instance.Aim();
        if (InputManager.Instance.VR_Mode()) {
            m_rect.position = delta;
        } else {
            m_rect.position = new Vector2(m_halfWitdh, m_halfHeigth);
        }

        Ray ray = m_camera.ScreenPointToRay(m_rect.position);

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.red);
        if (InputManager.Instance.Fire()) {
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