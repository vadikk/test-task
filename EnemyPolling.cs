using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPolling : MonoBehaviour {

	public static EnemyPolling enemypool;
	public GameObject enemy;
	private int countEnemy = 15;
	private List<GameObject> enemys;

	void Awake(){
		enemypool = this;
	}
	// Use this for initialization
	void Start () {
		enemys = new List<GameObject> ();
		for (int i = 0; i < countEnemy; i++) {
			GameObject obj = Instantiate (enemy) as GameObject;
			obj.transform.parent = this.transform;
			obj.gameObject.SetActive (false);
			enemys.Add (obj);
		}
	}

	public GameObject GetEnemyPool(){
		for (int i = 0; i < enemys.Count; i++) {
			if (!enemys [i].activeInHierarchy) {
				enemys [i].gameObject.SetActive (true);
				return enemys [i];
			}
		}
		return null;
	}
	

}
