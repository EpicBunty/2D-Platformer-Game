using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    Collider2D coll;

    [SerializeField] private GameOverController gameOverController;
    [SerializeField] private LevelCompleteMenu levelCompleteMenu;

    //private bool isJumping;

    [SerializeField] private float jumpforce;
    [SerializeField] private float jumpheldforce;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask jumpableGround;
    private float horizontal;
    private bool JumpPressed;
    private bool JumpHeld;
    private bool isCrouching;

    void Respawn()
    {
        transform.position = Vector3.zero;
    }

    public void OpenInGameMenu()
    {
        gameOverController.gameObject.SetActive(true);
        this.enabled = false;
    }

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        coll = gameObject.GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        InputsAndAnimations();
        RunAndFlip();
        JumpPress();
        EscMenu();
    }


    private void FixedUpdate()
    {
        JumpHold();
    }

    private void EscMenu()
    {
        if (Input.GetButtonDown("Cancel"))
        { OpenInGameMenu(); }
        else gameOverController.gameObject.SetActive(false);
    }

    private void InputsAndAnimations()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isCrouching = Input.GetKey(KeyCode.LeftControl);
        JumpPressed = Input.GetKeyDown(KeyCode.Space);
        JumpHeld = Input.GetKey(KeyCode.Space);


        //animator.SetBool("jump", isJumping);
        animator.SetFloat("y_velocity", rb2d.velocity.y);
        animator.SetFloat("x_velocity", rb2d.velocity.x);
        animator.SetBool("onground", OnGround());
        animator.SetBool("crouch", isCrouching);
        animator.SetFloat("speed", Mathf.Abs(horizontal));

    }

    private void RunAndFlip()
    {
        Vector2 position = transform.position;
        if (!isCrouching)
        {
            position.x = position.x + horizontal * speed * Time.deltaTime;
            transform.position = position;
        }

        Vector2 scale = transform.localScale;
        if (horizontal != 0 && scale.x != horizontal)
        {
            scale.x = horizontal;
            transform.localScale = scale;
        }
    }

    private void JumpPress()
    {
        if (OnGround() && JumpPressed)
        {
            rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }

        if (OnGround())
        {
            animator.SetBool("land", true);
        }
        else animator.SetBool("land", false);
    }

    private void JumpHold()
    {
        if (JumpHeld)
        {
            rb2d.AddForce(new Vector2(0, jumpheldforce), ForceMode2D.Force);
            //isJumping = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Respawn();
        }
        else if (collision.gameObject.CompareTag("LevelComplete"))
        {

            LevelManager.Instance.MarkCurrentLevelComplete();
            LevelManager.Instance.MarkNextLevelUnlocked();
            levelCompleteMenu.gameObject.SetActive(true);
           //LevelManager.Instance.LoadNextScene();
            //LevelManager.Instance.Init();

        }

    }

    private bool OnGround()
    {
        //RaycastHit2D raycastHit = 
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}


//
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

