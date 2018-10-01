using UnityEngine;
using UnityEngine.UI;

public class DamageFeedback : MonoBehaviour {
    [SerializeField] PlayerLife m_player;
    Image m_image;

    private void Awake() {
        m_image = GetComponent<Image>();
        m_player.damageTaken.AddListener(TakeHit);
    }

    private void Update() {
        float currAlpha = m_image.color.a;
        if (currAlpha > 0f) {
            SetAlpha(currAlpha - 0.05f);
        }
    }

    void TakeHit() {
        SetAlpha(0.8f);
    }

    void SetAlpha(float alpha) {
        Color color = m_image.color;
        color.a = alpha;
        m_image.color = color;
    }
}