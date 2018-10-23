﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraMovement : MonoBehaviour {
	[SerializeField] CameraRail m_cameraRail;
	[SerializeField] float m_speed = 1f;
	GeneralMovement m_movement;
	CameraCover m_cover;
	Transform nextPos;
	bool m_moving;
	NavMeshAgent navMeshAgent;


	private void Awake() {
		m_movement = GetComponent<GeneralMovement>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		m_cover = GetComponent<CameraCover>();
		m_movement.enabled = false;
	}

	private void Start() {
		NextArea();
	}

	void Update() {
		if (m_moving) {
			m_movement.enabled = false;
			if(navMeshAgent.enabled == true && navMeshAgent.remainingDistance < 0.1f 
					&& navMeshAgent.hasPath){

				navMeshAgent.enabled = false;
				transform.position = nextPos.position;
			}
			rotateToPoint();
		}
	}

	private void rotateToPoint(){
		float delta = Time.deltaTime * m_speed;
		transform.rotation = Quaternion.Lerp(transform.rotation,
			nextPos.rotation, delta);
		if(transform.rotation == nextPos.rotation){
			m_movement.enabled = true;
			m_moving = false;
		}
	}

	[ContextMenu("NextArea")]
	public void NextArea() {
		m_cameraRail.GetNextPosition(ref nextPos);
		m_movement.enabled = false;
		m_moving = true;
		if(nextPos != null)	{
			navMeshAgent.enabled = true;
			navMeshAgent.SetDestination(nextPos.position);
		}
	}

	void ToMove() {
		m_moving = true;
	}

	public bool IsMoving() {
		return m_moving;
	}

}