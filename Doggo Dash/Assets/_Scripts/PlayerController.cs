using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//Dog object
	private GameObject doge;

	//Rigidbody for dog object
	//private Rigidbody2D

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D myRigidBody;

	bool autoRun = true;

	bool crawling = false;
	bool hasJump = true;

	// Use this for initialization
	private void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	private void Update () {
		
		if (Input.GetKeyDown(KeyCode.DownArrow))
			crawl();

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			if (hasJump) {
				jump ();
			}
		}
		
		if (Input.GetKeyDown(KeyCode.LeftArrow))
			sit();

	}

	void FixedUpdate(){
		if (autoRun) {
			run ();
		}
	}

	private void crawl(){
		if (!crawling) {
			StartCoroutine (Crawl ());
		}
	}

	private IEnumerator Crawl(){
		//Stop parallax
		crawling = true;
		moveSpeed = moveSpeed - 4f;

		yield return new WaitForSeconds (1f);

		moveSpeed = moveSpeed + 4f;
		crawling = false;
	}

	private void jump(){
		myRigidBody.velocity = new Vector2 (moveSpeed, jumpForce);
		hasJump = false;
	}

	private void sit(){
		if (!autoRun) {
			StartCoroutine (Crawl ());
		}
	}

	private IEnumerator Sit(){
		//Stop parallax
		autoRun = false;
		myRigidBody.velocity = Vector2.zero;

		yield return new WaitForSeconds (1f);

		autoRun = true;
	}

	private void run(){
		myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);
	}

	private void OnCollisionEnter2D(Collision2D other){
		hasJump = true;
	}
}