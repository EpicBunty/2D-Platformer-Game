using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float velocity_y;
    public float Speed;
    public float jumpforce;
    //public bool OnGround;
    public bool JumpPressed;
    //public float vertical;
    [SerializeField] private LayerMask jumpableGround;
    private bool isCrouching;
    private Rigidbody2D rb2d;
    private Collider2D coll;
    public bool isJumping= false;


    
    private void Awake()
    {
       
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        //jumpableGround = "Ground";
    }

     void Update()
     {
        velocity_y = rb2d.velocity.y;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

       // MoveCharacter(horizontal, vertical);
        Run(horizontal);
        PlayerMovementAnimation(horizontal, vertical);
        if (OnGround())
            isJumping = false;
        if (vertical > 0) 
            JumpPressed = true;
        //Jump();

    }

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

    private void FixedUpdate()
    {
        if (JumpPressed)// && OnGround)
            Jump();
    }
    /*private void PlayerMovement(float horizontal)
    {
        if (!isCrouching)
        {
            Run(horizontal);
        }
    }*/

    private void Run(float horizontal)
    {
        if (!isCrouching)
        {
            Vector3 position = transform.position;
            position.x = position.x + horizontal * Speed * Time.deltaTime;
            transform.position = position;
            animator.SetFloat("speed", Mathf.Abs(horizontal));
        }
    }

    private void Jump()
    {
        if (OnGround())
        {
            rb2d.AddForce(new Vector2(0, jumpforce),ForceMode2D.Impulse);
            isJumping = true;
            JumpPressed = false;
        }
    }

    private void PlayerMovementAnimation(float horizontal, float vertical)

    {
        Flip(horizontal);
        JumpandCrouch(vertical);
    }

    private void JumpandCrouch(float vertical)
    {
        if (vertical > 0)
        {
            animator.SetBool("jump", true);
            //animator.SetFloat("y_velocity", rb2d.velocity.y);
        }
        else if (isJumping)
        {
            //animator.SetBool("jump", true);
            animator.SetFloat("y_velocity", rb2d.velocity.y);
        }
        else if (OnGround())
        {
            animator.SetBool("jump", false);
            //animator.SetFloat("velocity", rb2d.velocity.y);
            /*animator.Play("Player_Jump_Land");
            animator.SetBool("jump", false);*/
        }

        //animator.SetBool("jump", false);

        if (vertical < 0)
        {
            isCrouching = true;
            animator.SetBool("crouch", true);
        }
        else 
        {
            isCrouching = false;
            animator.SetBool("crouch", false);
        }
    }

    private void Flip(float horizontal)
    {
        Vector3 scale = transform.localScale;

        if (horizontal < 0 && scale.x > 0)
            scale.x = -1f * Mathf.Abs(scale.x);

        else if (horizontal > 0 && scale.x < 0)
            scale.x = Mathf.Abs(scale.x);

        transform.localScale = scale;
    }

    private bool OnGround()
    {
        //RaycastHit2D raycastHit = 
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        /*Color rayColor;
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
        return raycastHit.collider != null;*/

    }
    
    void Respawn()
    {
        transform.position = Vector3.zero;
    }


    ////////////////////////////////////////
    private void OnTriggerEnter2D(Collider2D collision)
    { 
         if (collision.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Death by falling");
            Respawn();
        }
    }
    
}
