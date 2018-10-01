using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler,
    IPointerUpHandler, IPointerDownHandler {

        Image m_bgImage;
        Image m_joystickImage;
        Vector2 m_inputVector;

        private void Awake() {
            m_bgImage = GetComponent<Image>();
            m_joystickImage = transform.GetChild(0).GetComponent<Image>();
        }

        public void OnDrag(PointerEventData eventData) {
            Vector2 pos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    m_bgImage.rectTransform, eventData.position,
                    eventData.pressEventCamera, out pos)) {

                pos.x = pos.x / m_bgImage.rectTransform.sizeDelta.x;
                pos.y = pos.y / m_bgImage.rectTransform.sizeDelta.y;

                m_inputVector = new Vector2(
                    pos.x * 2f, pos.y * 2f);
                if (m_inputVector.magnitude > 1f) {
                    m_inputVector = m_inputVector.normalized;
                }
                m_joystickImage.rectTransform.anchoredPosition = new Vector2(
                    m_inputVector.x * (m_bgImage.rectTransform.sizeDelta.x / 3f),
                    m_inputVector.y * (m_bgImage.rectTransform.sizeDelta.y / 3f));
                print(m_inputVector);
            }
        }

        public void OnPointerDown(PointerEventData eventData) {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData) {
            m_inputVector = Vector2.zero;
            m_joystickImage.rectTransform.anchoredPosition = Vector2.zero;
        }

        public float Vertical() {
            return m_inputVector.y;
        }

        public float Horizontal() {
            return m_inputVector.x;
        }

        public Vector2 Direction() {
            return m_inputVector;
        }
    }