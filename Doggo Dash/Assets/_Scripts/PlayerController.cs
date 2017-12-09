using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//Dog object
	private GameObject doge;

	//Rigidbody for dog object
	//private Rigidbody2D

	public float moveSpeed;
	public float jumpForce;

    public Swipe swipeControls;

	private Rigidbody2D myRigidBody;

	bool autoRun = true;

	bool crawling = false;
    bool sitting = false;
	bool hasJump = true;
	private bool hit = false;
    bool dead = false;
	public SpriteRenderer sprite;
	public GameController gc;
	// Use this for initialization
	private void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
	}

	public void Hit() {
		
		if (hit == false) {
            AudioController.Instance.PlaySFX("Dogs Bark #5");
			gc.liveStocks -= 1;
			if (gc.liveStocks < 0) {
                gc.Restart();
                dead = true;
			} else {
				StartCoroutine (Blink ());
			}
		}
	}

	public IEnumerator Blink(){
		hit = true;
		float timer = 0f;
		bool visible = true;
		while (timer < 2f) {
			if (visible) {
				sprite.color = Color.white;
			} else {
				sprite.color = Color.clear;
			}
			visible = !visible;
			timer += .2f;
			yield return new WaitForSeconds (.2f);
		}
		sprite.color = Color.white;
		hit = false;
	}
	// Update is called once per frame
	private void Update () {
        if (dead)
        {
            return;
        }

        if (swipeControls.SwipeDown)
        {
            crawl();
            Debug.Log("Crawl");
        }

		if (swipeControls.SwipeUp) {
			if (hasJump) {
				jump ();
                Debug.Log("Jump");
			}
		}

        if (swipeControls.SwipeLeft)
        {
            sit();
            Debug.Log("Sit");
        }

	}

	void FixedUpdate(){
		if (autoRun && !sitting && !crawling) {
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
		if (!sitting) {
			StartCoroutine (Sit ());
		}
	}

	private IEnumerator Sit(){
		//Stop parallax
		autoRun = false;
		myRigidBody.velocity = Vector2.zero;
        sitting = true;

		yield return new WaitForSeconds (1f);

		autoRun = true;
        sitting = false;
	}

	private void run(){
		myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);
	}

	private void OnCollisionEnter2D(Collision2D other){
		hasJump = true;
	}
}