using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour {
	
	public static BulletPooling bulletpool;
	public GameObject bullet;
	private int countBullet = 20;
	private List<GameObject> bullets;

	void Awake(){
		bulletpool = this;
	}
	// Use this for initialization
	void Start () {
		bullets = new List<GameObject> ();
		for (int i = 0; i < countBullet; i++) {
			GameObject obj = Instantiate (bullet) as GameObject;
			obj.transform.parent = this.transform;
			obj.SetActive (false);
			bullets.Add (obj);
		}
	}

	public GameObject GetBullet(){
		for (int i = 0; i < bullets.Count; i++) {
			if (!bullets [i].activeInHierarchy) {
				bullets [i].gameObject.SetActive (true);
				return bullets [i];
			}
		}
		return null;
	}
	
	
}
