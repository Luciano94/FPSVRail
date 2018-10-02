using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : MonoBehaviour {

	[SerializeField] private float minTime;
	[SerializeField] private float maxTime;
	private float time;
	private float currentTime;
	private float m_FireTime = 0.0f;
	[SerializeField] private GameObject m_BulletObject;
	[SerializeField] private Vector2 m_Offset;
	private ObjectPool m_pool;

	private void Awake() {
		m_pool = GetComponentInParent<ObjectPool>();
	}

	private void OnEnable() {
		time = Random.Range(minTime, maxTime);
		currentTime = 0;
	}

	void Update() {
		currentTime += Time.deltaTime;
		if (Time.time > m_FireTime) {
			this.m_FireTime = Time.time + (float)Random.Range(this.m_Offset.x, this.m_Offset.y);
			GameObject bullet;
			if (m_pool.Request(out bullet)) {
				bullet.transform.position = transform.position;
				bullet.transform.rotation = transform.rotation;
			}
		}
		if (currentTime > time) {
			GetComponent<StateMachine>().ActivateState(StateMachine.States.FireToCoverState);
		}
	}
}