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
	CameraCover cameraCover;

	private void Awake() {
		m_movement = GetComponent<GeneralMovement>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		cameraCover = GetComponent<CameraCover>();
		m_movement.enabled = false;
	}

	private void Start() {
		NextArea();
	}

	void Update() {
		Vector3 target = new Vector3(nextPos.position.x, transform.position.y, nextPos.position.z);
		float dist = Vector3.Distance(transform.position,target);
		if (m_moving) {
			cameraCover.enabled = false;
			m_movement.enabled = false;
			float distY = Mathf.Abs(transform.position.y - nextPos.position.y);
			Debug.Log("dist Y: " + distY);
			if(navMeshAgent.enabled == true && dist < 0.1f &&  navMeshAgent.hasPath){
				
				navMeshAgent.enabled = false;
				transform.position = nextPos.position;
			}
			if(dist < 0.1f) rotateToPoint();
		}
	}

	private void rotateToPoint(){
		float delta = Time.deltaTime * m_speed;
		transform.rotation = Quaternion.Lerp(transform.rotation,
			nextPos.rotation, delta);
		if(transform.rotation == nextPos.rotation){
			if(!InputManager.Instance.VRmode)
				m_movement.enabled = true;
			m_moving = false;
			cameraCover.enabled = true;
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