using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //this lets me reload scene below



public class PlayerController : MonoBehaviour {



    public new CameraFollower camera;       // Store a reference to the main camera following us
    private Rigidbody2D rb2d;               // Store a reference to the Rigidbody2D component required to use 2D Physics.

    public float maxHealth = 10;
    private float health = 10;
    private float damage = 2;
    private string direction;
    public float atkCD = 0.5f;
    private float atkTimer;
    private GameObject cdBar;
    private RectTransform cdRect;
    private float cdWidth;
    private GameObject playerLight;
    private float torchTimer;
    public float torchDuration = 10f;
    private GameObject torchSpawner;


    //movement variables
    public float speed;                     // Floating point variable to store the player's movement speed.
    private Animator anim;                  // Store a reference to the Animator component
    float lastX;
    float lastY;

    //animator variables





    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direction = "right";
        health = maxHealth;

        cdBar = GameObject.FindGameObjectWithTag("cdBar");
        cdBar.GetComponent<Image>().enabled = false;

        playerLight = GameObject.FindGameObjectWithTag("playerLight");
        playerLight.GetComponent<Light>().enabled = true;

        torchSpawner = GameObject.FindGameObjectWithTag("torchSpawner");

    }

    /*
	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		//==========================
		// MOVE POSITION CONTROLLER
		//==========================


		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//Use rigidbody to move position to new movement vector2
		rb2d.MovePosition (new Vector2 (
			(transform.position.x + movement.x * speed * Time.deltaTime),
			(transform.position.y + movement.y * speed * Time.deltaTime)));
		

	






		//======================
		// ANIMATION CONTROLLER
		//======================



		/*

		// MOVEMENT
		//=========

		// Walk West
		if (moveHorizontal < 0) {
			anim.SetInteger("State", 5);
		}

		// Walk East
		if (moveHorizontal > 0)
		{
			anim.SetInteger("State", 7);
		}

		// Idle East
		if ((moveHorizontal == 0) && (direction == "right"))
		{
			anim.SetInteger("State", 3);
		}

		// Idle West
		if ((moveHorizontal == 0) && (direction == "right"))
		{
			anim.SetInteger("State", 1);
		}




		// ATTACK
		//========

		if (Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("attack", true);
		}


	}

	*/

    void FixedUpdate() {
        Move();
    }


    void Update() {
        if (health == 0 || health < 0) {
            OnPlayerDeath();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 2")) {
            Attack ();
		}

		atkTimer += Time.deltaTime; // timer for attack cooldown
		//Debug.Log("Timer: " + atkTimer);

		if (cdBar.GetComponent<Image> ().enabled == true) {
			cdRect = cdBar.GetComponent<RectTransform> ();
			cdWidth = cdRect.rect.width;
			cdWidth -= ((cdWidth) * (atkTimer/atkCD)); 
		}
		if (cdWidth == 0 || cdWidth < 0) {
			cdBar.GetComponent<Image> ().enabled = false;
		}

		torchTimer += Time.deltaTime; //timer for torch running out when held
		//Debug.Log ("Torch Timer: " + torchTimer);

		if (playerLight.GetComponent<Light> ().enabled == true && torchTimer > torchDuration) {
			playerLight.GetComponent<Light> ().enabled = false;
		}

	}



	void Move() {

		Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * Input.GetAxis ("Horizontal");
		Vector3 upMovement = Vector3.up * speed * Time.deltaTime * Input.GetAxis ("Vertical");

		Vector3 heading = Vector3.Normalize (rightMovement + upMovement);

		transform.position += rightMovement;
		transform.position += upMovement;

		UpdateAnimation(heading);

	}

	void Move2() {
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, transform.position.z);

		//Use rigidbody to move position to new movement vector2
		rb2d.MovePosition (new Vector2 (
			(transform.position.x + movement.x * speed * Time.deltaTime),
			(transform.position.y + movement.y * speed * Time.deltaTime)));

		UpdateAnimation (movement);



	}




	private void OnCollisionEnter2D(Collision2D collision)
	{
		//if (Input.GetKeyDown (KeyCode.Space)) {
		//collision.gameObject.GetComponent<IInteractable>().Interact();
		if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<enemyFollowv2>().Attack();
			health = health - damage;
			Debug.Log ("health = " + health); //this makes you lose health if you hit walls too, rip
		}


		//}
	}

	private void OnTriggerStay2D(Collider2D collider) {
		

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown("joystick button 2")) {
			if (atkTimer > atkCD) {
				Attack ();

				if (collider.gameObject.GetComponent<IInteractable> () != null) {
					collider.gameObject.GetComponent<IInteractable> ().Interact ();
					cdBar.GetComponent<Image> ().enabled = true;
					//Debug.Log ("in range to attack");


				}
				if (collider.gameObject.tag == "Torch") {
					torchSpawner.GetComponent<IInteractable> ().Interact ();
					playerLight.GetComponent<Light> ().enabled = true;
					torchTimer = 0;
				}

				atkTimer = 0;
			} else {
				Debug.Log ("attack is on cooldown");

			}
		}
	}

	public void TakeDamage(float damage) {



	}

	void Attack(){
		anim.SetTrigger ("Attack");
	}

	void UpdateAnimation(Vector3 dir) {

		if (dir.x == 0f && dir.y == 0f)
		{
			//if we are idle, then execute idle animation
			anim.SetFloat ("LastDirX", lastX);
			anim.SetFloat ("LastDirY", lastY);
			anim.SetBool ("Movement", false);
		}
		else
		{
			lastX = dir.x;
			lastY = dir.y;
			anim.SetBool ("Movement", true);
		}

		anim.SetFloat ("DirX", dir.x);
		anim.SetFloat ("DirY", dir.y);
	}


	public float GetHealth() {
		return health;
	}

    void OnPlayerDeath()
    {
        GameManager.instance.OnPlayerDeath();
    }

    //SceneManager.LoadScene("EndMenu");

}