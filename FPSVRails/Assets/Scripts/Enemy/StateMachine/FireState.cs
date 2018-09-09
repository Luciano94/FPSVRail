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

	private void OnEnable()
	{
		time = Random.Range(minTime, maxTime);
		currentTime = 0;
	}

	void Update()
	{
		currentTime += Time.deltaTime;
		if(Time.time > m_FireTime){
			this.m_FireTime = Time.time + (float)Random.Range(this.m_Offset.x, this.m_Offset.y);
			GameObject bulletClone = (GameObject)Instantiate(m_BulletObject, transform.position, transform.rotation);
		}
		if (currentTime > time){
			GetComponent<StateMachine>().ActivateState(StateMachine.States.FireToCoverState);
		}
	}
}
