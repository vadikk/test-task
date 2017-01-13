using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public Transform [] spawntrans;
	private int timespawn = 2;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn" ,timespawn, timespawn);
	}

	void Spawn(){
		GameObject obj = EnemyPolling.enemypool.GetEnemyPool ();
		if (obj == null)
			return;
		int indexSpawn = Random.Range (0, spawntrans.Length); 
		obj.transform.position = spawntrans [indexSpawn].transform.position;
		obj.transform.rotation = spawntrans [indexSpawn].rotation;
		obj.gameObject.SetActive (true);

	}
	

}
