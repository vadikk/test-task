using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

	Transform tank;
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		tank = GameObject.Find ("Tank").transform;
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (tank.position);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Bullet") {
			other.gameObject.SetActive (false);
			gameObject.SetActive (false);
		}
	}
}
