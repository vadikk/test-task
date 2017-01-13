using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

	public Transform bulletSpawner;

	private Vector3 posRotate;
	private Vector3 targetPosition;
	private float timeCount;
	private bool movetank = false;
	private bool canturn = false;
	private bool canfire = false;
	private float yAxis;
	private Rigidbody rigid;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		yAxis = transform.position.y;
	}

	// Update is called once per frame
	void Update () {

		if (canturn) {
			Turning ();
		}
		if (canfire) {
			Fire ();
			canfire = false;
		}


		Ray pos = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(pos, out hit)){
			if (Input.touchCount > 0) {
				Touch touch = Input.GetTouch (0);
				if (touch.phase == TouchPhase.Began) {
					timeCount = 0f;
				} else if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
					timeCount += Time.deltaTime;
				} else if (touch.phase == TouchPhase.Ended) {
					if (timeCount >= 2f) {
						movetank = true;
						targetPosition = hit.point;
						targetPosition.y = yAxis;
					} else if (timeCount < 1f) {
						canturn = true;
						posRotate = hit.point;
						canfire = true;
					}
				}
			}
			print (timeCount);
		}
		if (movetank) {
			transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);

			if ((transform.position - targetPosition).magnitude < 0.1f) {
				movetank = false;
			}
		}
	}

	void Turning(){
		Vector3 t = posRotate - transform.position;
		Quaternion rotate = Quaternion.LookRotation (t, Vector3.up);
		rotate = rotate * Quaternion.Euler(0f, -90f, 0f);
		print ("angle"+rotate);
		transform.rotation = Quaternion.Lerp (transform.rotation, rotate, Time.deltaTime/2);
		print("mag"+(transform.position - posRotate).magnitude);
		if ((transform.position - posRotate).magnitude < 0.1f) {
			canturn = false;
		}
	}

	void Fire(){
		GameObject obj = BulletPooling.bulletpool.GetBullet ();
		if (obj == null)
			return;
		obj.transform.position = bulletSpawner.position;
		obj.transform.rotation = bulletSpawner.rotation;
		obj.gameObject.SetActive (true);
	}
}
