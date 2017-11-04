using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject parent;

	public GameObject obj;

	public GameObject lastObj;

	public float spawnOffset;
	public float offsetX;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Spawn ();
		}
	}

	public void Spawn(){

		GameObject newObj = (GameObject) Instantiate (obj, parent.transform);

		newObj.transform.localPosition = new Vector3 (lastObj.transform.position.x + offsetX, 0, 0f);

		transform.position = new Vector3 (transform.position.x + spawnOffset, transform.position.y, transform.position.z);
		lastObj = newObj;
	}
}
