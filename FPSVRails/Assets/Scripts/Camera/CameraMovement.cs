using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraMovement : MonoBehaviour {
	[SerializeField] CameraRail m_cameraRail;
	[SerializeField] float m_speed = 1f;
	GeneralMovement m_movement;
	Transform nextPos;
	bool m_moving;
	NavMeshAgent navMeshAgent;


	private void Awake() {
		m_movement = GetComponent<GeneralMovement>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		m_movement.enabled = false;
	}

	private void Start() {
		NextArea();
	}

	void Update() {
		//Debug.Log(m_moving + " " + navMeshAgent.remainingDistance);
		if (m_moving) {
			if(navMeshAgent.remainingDistance < 0.5){
				navMeshAgent.enabled = false;
				transform.position = nextPos.position;
				transform.rotation = nextPos.rotation;
				m_movement.enabled = true;
				m_moving = false;
			}
			
			/*navMeshAgent.enabled = true;
			float distance = Vector3.Distance(transform.position, nextPos.position);
			if (distance > 1) {
				navMeshAgent.SetDestination(nextPos.position);
				/*float distance = Vector3.Distance(transform.position, nextPos.position);
				float delta = Time.deltaTime * (m_speed / distance);
				transform.position = Vector3.Lerp(transform.position,
					nextPos.position, delta);
				transform.rotation = Quaternion.Lerp(transform.rotation,
					nextPos.rotation, delta);
			}else {
					navMeshAgent.enabled = false;
					m_movement.enabled = true;
					m_moving = false;
					transform.position = nextPos.position;
					transform.rotation = nextPos.rotation;
			}*/
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

	public bool IsMoving() {
		return m_moving;
	}

}