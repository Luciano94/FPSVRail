using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMovement : MonoBehaviour {
	[SerializeField] private float speed;
    [SerializeField] private Vector2 minLimit;
    [SerializeField] private Vector2 maxLimit;
    private float  rotVert = 0f;
    private float rotHor = 0f;

    private void Awake() {
        BuscarAngulos();
    }
    private void Update() {
        Movement(); 
    }

    private void BuscarAngulos() {
        minLimit.x -= transform.eulerAngles.x;
        minLimit.y = transform.eulerAngles.y + minLimit.y;
        maxLimit.x += transform.eulerAngles.x;
        maxLimit.y += transform.eulerAngles.y;
    }
    private void Movement(){
        rotVert += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        rotVert = Mathf.Clamp(rotVert , minLimit.x, maxLimit.x);
        rotHor -= Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rotHor = Mathf.Clamp(rotHor, minLimit.y, maxLimit.y);

        transform.eulerAngles = new Vector3(-rotVert,-rotHor,0);
    }
}
