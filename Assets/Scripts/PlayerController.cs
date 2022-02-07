using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    Collider2D coll;

    LevelController levelController;
    public GameOverController gameOverController;
    public ScoreController scoreController;


    [SerializeField] private float Speed;
    [SerializeField] private float jumpforce;
    [SerializeField] private float jumpheldforce;  //can remove
    [SerializeField] private float vertical; // can remove
    [SerializeField] private float horizontal;
    [SerializeField] private float movespeed;

   // [SerializeField] private bool onground;
    //[SerializeField] private bool isJumping;
    [SerializeField] private bool JumpPressed;
    [SerializeField] private bool JumpHeld;

    [SerializeField] private bool isCrouching;
    [SerializeField] private LayerMask jumpableGround;

    
      /*  private Rigidbody2D rb2d;
        //private Animator animator;
        private Collider2D coll;
        public LEVELCONTROL level;*/


    /*private string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_RUN = "Player_Run";
    const string PLAYER_JUMP_UP = "Player_Jump_Up";
    const string PLAYER_JUMP_DOWN = "Player_Jump_Down";
    const string PLAYER_JUMP_LAND = "Player_Jump_Land";*/

    /*void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;  }*/
  

    void Respawn()
    {
        transform.position = Vector3.zero;
    }

    public void OpenInGameMenu()
    {
        gameOverController.gameObject.SetActive(true);
        //gameOverController.InGameMenu(true);
        this.enabled = false;
        //Time.timeScale = 0;
    }

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        levelController = gameObject.GetComponent<LevelController>();
    }


    void Update()
    {
        /*onground = rb2d.velocity.y == 0;*/
        //isJumping= !onground;

        InputsAndAnimations();
        Run();
        Flip();
        JumpPress();
        if (Input.GetButtonDown("Cancel"))
        {
            OpenInGameMenu();
        }
        /*if (OnGround())//(rb2d.velocity.y==0)
        {
            isJumping = false;

            *//*JumpHeld = false;
            JumpPressed = false;*//*
        }*/


        //PlayerMovementAnimation(horizontal, vertical);
    }

    private void FixedUpdate()
    {
        JumpHold();
    }

    /* private void JumpMethod()
     {
         if (JumpPressed)
         {
             Debug.Log("JUMP PRESSED");
             Jump();
         }
         *//*if (JumpHeld)
         {
             rb2d.AddForce(new Vector2(0, jumpheldforce), ForceMode2D.Force);
             Debug.Log("applying JUMP HELD FORCE");
         }*//*
     }*/

    private void InputsAndAnimations()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isCrouching = Input.GetKey(KeyCode.LeftControl);
        JumpPressed = Input.GetKeyDown(KeyCode.Space);
        JumpHeld = Input.GetKey(KeyCode.Space);

        animator.SetFloat("y_velocity", rb2d.velocity.y);
        animator.SetFloat("x_velocity", Mathf.Abs(rb2d.velocity.x));//Mathf.Abs(horizontal));
        animator.SetBool("jump", JumpPressed);// isJumping);
        animator.SetBool("onground", OnGround());//OnGround());
        animator.SetBool("crouch", isCrouching);
        animator.SetFloat("speed", Mathf.Abs(horizontal));

    }

    private void Run()
    {
        if (!isCrouching)
        {
            Vector2 position = transform.position;
            position.x = position.x + horizontal * Speed * Time.deltaTime;
            transform.position = position;
        }
    }
    private void JumpPress()
    {
        if (OnGround() && JumpPressed)
        {
            rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            //isJumping = true;
            //Debug.Log("jump pressed and ongound = JUMPING");
        }
    }

    private void JumpHold()
    {
        if (JumpHeld)
        {
            rb2d.AddForce(new Vector2(0, jumpheldforce), ForceMode2D.Force);
            //Debug.Log("applying JUMP HELD FORCE");
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;

        if (horizontal < 0 && scale.x > 0)
            scale.x *= -1f;// * Mathf.Abs(scale.x);

        else if (horizontal > 0 && scale.x < 0)
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {

            Respawn();
        }
        else if (collision.gameObject.CompareTag("SceneManagement"))
        {
            levelController.LoadNextScene();
        }
        else if (collision.gameObject.CompareTag("Collectible"))
        {
            scoreController.ScoreIncrement(10);
            //ScoreController.ScoreIncrement(10);
            Destroy(collision.gameObject);
        }
    }

    private bool OnGround()
    {
        //RaycastHit2D raycastHit = 
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        /**//*Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(coll.bounds.center + new Vector3(coll.bounds.extents.x, 0), Vector2.down * (coll.bounds.extents.y), rayColor);
        Debug.DrawRay(coll.bounds.center - new Vector3(coll.bounds.extents.x, 0), Vector2.down * (coll.bounds.extents.y), rayColor);
        Debug.DrawRay(coll.bounds.center - new Vector3(coll.bounds.extents.x, coll.bounds.extents.y), Vector2.right * (coll.bounds.extents.x), rayColor);
        return raycastHit.collider != null;*//*

    }*/
    }
    ////////////////////////////////////////
    /*private static void LoadNextScene()
    {
        int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Collided with endlevelobject and loading scene " + NextScene);
        SceneManager.LoadScene(NextScene);
    }*/
}
/* public void ReloadLevel()
 {
     string currentscene = SceneManager.GetActiveScene().name;
     SceneManager.LoadScene(currentscene);
     //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

 }*/

/* private void MoveCharacter(float horizontal, float vertical)
 {

         PlayerMovement(horizontal);

     *//*if (vertical > 0 && OnGround)
         Jump(vertical);*//*

     //jump method 2
     *//*else if (vertical > 0 && Mathf.Abs(rb2d.velocity.y) < 0.001f)
     {
         rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
     }*//*

 }*/