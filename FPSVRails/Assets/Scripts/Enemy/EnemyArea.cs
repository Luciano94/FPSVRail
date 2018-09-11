using UnityEngine;

public class EnemyArea : MonoBehaviour {
    [SerializeField] AreaController m_areaController;

    public void SetAreaController(AreaController areaController) {
        m_areaController = areaController;
    }

    private void OnDestroy() {
        m_areaController.Remove(this);
    }
}