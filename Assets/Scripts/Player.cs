using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //floats
    public float maxSpeedSet = 3f;
	public float maxSpeed = 3f;
	public float jumpSpeed = 2f;
    public float speed = 50f;
    public float jumpPower = 150f;
	public float doubleJumpPower = 1.25f;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;
	private object monkey;
	public PlayerSpawn spawnPos;
	public static Player playerInstance;


    //booleans
    public bool grounded;
    public bool canDoubleJump;
	public bool dead;
	public bool onLadder;

    //refrences
    private Rigidbody2D rb2d;
    private Animator anim;
	public GameObject DeathUI;
	private AudioSource audioPlayer;
	public AudioClip jumpBreath;

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad (this);

		/*if(playerInstance == null){
			playerInstance = this;
		}
		else if(!dead){
			DestroyObject (gameObject);
		}
		*/

		//spawnPos.SetSpawn(new Vector3 (-41, 52, 0));

		transform.position = spawnPos.getSpawn ();

        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
		DeathUI.SetActive (false);
		audioPlayer = GetComponent<AudioSource> ();
		gravityStore = rb2d.gravityScale;
		//monkey = gameObject.Find("Monkey"); 
    }
	
	// Update is called once per frame
	void Update () {

		//CheckPoints


        anim.SetBool("Grounded",grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

		//Stop rotation
		transform.rotation = Quaternion.Euler(0, 0, 0);

		//			TURNING
		if(Input.GetAxis("Horizontal") < 0f) 			// facing left
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (Input.GetAxis("Horizontal") > 0f)	// facing right
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

		//			Put max speed back to max speed set
		if (grounded)
		{
			maxSpeed = maxSpeedSet;
		}

		//			JUMP
        if(Input.GetButtonDown("Jump"))
        {
			maxSpeed = jumpSpeed;
            if (grounded)
            {
				rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
				audioPlayer.PlayOneShot(jumpBreath, 1.0F);
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
				grounded = false;
            }
            else
            {
                if(canDoubleJump)
                {
					rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
					audioPlayer.PlayOneShot(jumpBreath, 1.0F);
                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
					rb2d.AddForce(Vector2.up * jumpPower / doubleJumpPower);
                }
            }
        }

		//			LADDER (Climbing Vine)
		//Trying to get work only after animal picked up
		if (onLadder) {
			rb2d.gravityScale = 0f;

			climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");

			rb2d.velocity = new Vector2 (rb2d.velocity.x, climbVelocity);
		} 
		else if (!onLadder) {
			rb2d.gravityScale = gravityStore;
		}

		//			Death
		if(dead)
		{
			Time.timeScale = 0;
			gameObject.SetActive (false);
			DeathUI.SetActive (true);
		}
    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        //Fake friction
        if(grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        // moves player
        rb2d.AddForce((Vector2.right * speed) * h);

        // Limit speed
        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }
}
