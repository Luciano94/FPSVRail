using UnityEngine;

public class EnemyArea : MonoBehaviour {
    AreaController m_areaController;

    public void SetAreaController(AreaController areaController) {
        m_areaController = areaController;
    }

    private void OnDisable() {
        m_areaController.Remove(this);
    }
}