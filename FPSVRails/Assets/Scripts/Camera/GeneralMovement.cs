using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMovement : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private Vector2 minLimit;
    [SerializeField] private Vector2 maxLimit;
    private float rotVert = 0f;
    private float rotHor = 0f;
    Vector3 rotation;

    private void OnEnable() {
        BuscarAngulos();
    }
    private void Update() {
        Movement();
    }

    private void BuscarAngulos() {
        rotHor = 0f;
        rotVert = 0f;
        rotation = transform.localEulerAngles;
    }

    private void Movement() {
        Vector2 camInput = InputManager.Instance.CameraMovement();
        rotVert += camInput.y * speed * Time.deltaTime;;
        rotVert = Mathf.Clamp(rotVert, minLimit.x, maxLimit.x);
        rotHor += camInput.x * speed * Time.deltaTime;
        rotHor = Mathf.Clamp(rotHor, minLimit.y, maxLimit.y);
        Vector3 rot = new Vector3(-rotVert, rotHor, 0);
        rot += rotation;
        transform.localEulerAngles = rot;
    }

}