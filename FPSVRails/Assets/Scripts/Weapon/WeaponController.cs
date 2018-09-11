using UnityEngine;
public class WeaponController : MonoBehaviour {
    [SerializeField] LayerMask m_enemiesLayer;
    [SerializeField] float m_radius;
    [SerializeField] int m_damage;

    private void Update() {
        float dx = Input.GetAxis("AimX");
        float dy = -Input.GetAxis("AimY");
        if (dx != 0f || dy != 0f) {
            Vector3 newPos = transform.localPosition;
            newPos.x += dx;
            newPos.y += dy;
            transform.localPosition = newPos;
        }
        Debug.DrawLine(transform.position, transform.position + transform.forward * 100f, Color.red);
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, m_radius,
                    transform.forward, out hit, m_enemiesLayer)) {

                hit.transform.GetComponent<EnemyHealth>().Damage(m_damage);
            }
        }
    }

}