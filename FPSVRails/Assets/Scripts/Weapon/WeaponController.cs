using UnityEngine;
public class WeaponController : MonoBehaviour {
    [SerializeField] LayerMask m_enemiesLayer;
    [SerializeField] float m_radius;
    [SerializeField] int m_damage;
    [SerializeField] Camera m_camera;
    RectTransform m_rect;

    private void Awake() {
       m_rect = GetComponent<RectTransform>();
    }

    private void Update() {
        float dx = Input.GetAxis("AimX");
        float dy = -Input.GetAxis("AimY");
        if (dx != 0f || dy != 0f) {
            Vector3 newPos = transform.localPosition;
            newPos.x += dx;
            newPos.y += dy;
            transform.localPosition = newPos;
        }
        Vector3 start = m_camera.ScreenToWorldPoint(new Vector3(
            m_rect.position.x,
            m_rect.position.y,
            m_camera.nearClipPlane
        ));
        
        Ray ray = m_camera.ScreenPointToRay(m_rect.position);
        
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.red);
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.SphereCast(ray.origin, m_radius,
                    ray.direction, out hit, 100f, m_enemiesLayer)) {

                hit.transform.GetComponent<EnemyHealth>().Damage(m_damage);
            }
        }
    }

}