using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	private static EnemyManager instance;
	public static EnemyManager Instance{
		get{
			instance = FindObjectOfType<EnemyManager>();
			if(instance == null){
				GameObject go = new GameObject("EnemyManager");
				instance = go.AddComponent<EnemyManager>();
			}
			return instance;
		}
	}
	[SerializeField] private List<GameObject> groups;
	[SerializeField] private Queue<GameObject> groupsOfEnemies;
	private void Awake() {
		groupsOfEnemies = new Queue<GameObject>();
		foreach(GameObject go in groups){
			groupsOfEnemies.Enqueue(go);
			go.GetComponent<EnemyGroup>().enabled = false;
		}
	}

	public void ActiveGroup(){
		if(groupsOfEnemies.Count != 0)
			groupsOfEnemies.Dequeue().GetComponent<EnemyGroup>().enabled = true;
	}
}
