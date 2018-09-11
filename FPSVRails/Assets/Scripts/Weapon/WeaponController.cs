using UnityEngine;
public class WeaponController : MonoBehaviour {
    [SerializeField] LayerMask m_enemiesLayer;
    [SerializeField] float m_radius;
    [SerializeField] int m_damage;
    [SerializeField] Camera m_camera;
    [SerializeField] float m_sensitivity;
    RectTransform m_rect;

    private void Awake() {
       m_rect = GetComponent<RectTransform>();
    }

    private void Update() {
        float dx = Input.GetAxis("AimX") * m_sensitivity;
        float dy = -Input.GetAxis("AimY") * m_sensitivity;
        if (dx != 0f || dy != 0f) {
            Vector3 newPos = transform.localPosition;
            newPos.x += dx;
            newPos.y += dy;
            transform.localPosition = newPos;
        }

        Ray ray = m_camera.ScreenPointToRay(m_rect.position);
        
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.red);
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.SphereCast(ray.origin, m_radius,
                    ray.direction, out hit, 100f)) {

                EnemyHealth enemyHealth;
                if (enemyHealth = hit.transform.GetComponent<EnemyHealth>()){
                    enemyHealth.Damage(m_damage);
                }
            }
        }
    }

}