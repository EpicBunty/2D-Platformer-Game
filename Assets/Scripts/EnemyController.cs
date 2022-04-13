using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movespeed;
    public Animator animator;
    public bool facingright;
    [SerializeField] private float DirectionFacing;

    private bool movingright;
    private Rigidbody2D rb;
    //private Vector2 Scale;
    public HealthController health;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        DirectionFacing = gameObject.transform.localScale.x;

        CheckDirectionFacing();

        Movement();
    }

    private void CheckDirectionFacing()
    {
        if (DirectionFacing > 0)
        {
            facingright = true;
        }
        else
        {
            facingright = false;
        }
    }

    void Movement()
    {
        MoveRight();
        MoveLeft();
        //if (rb.position.x != 0)
        //animator.Play("Chomper Walk");
        //Flip();
    }
    private void MoveRight()
    {
        if (facingright)
        {
            Vector3 move = transform.position;
            move.x = move.x + 1 * Time.deltaTime * movespeed;
            transform.position = move;
            movingright = true;
            animator.Play("Chomper Walk");
        }
    }
    private void MoveLeft()
    {
        if (!facingright)
        {
            Vector3 move = transform.position;
            move.x = move.x - 1 * Time.deltaTime * movespeed;
            transform.position = move;
            movingright = false;
            animator.Play("Chomper Walk");
        }
    }

    void ReverseDirection()
    {
        Vector3 Scale = transform.localScale;
        if (movingright)
            Scale.x *= -1;
        else Scale.x = Mathf.Abs(Scale.x * 1);
        transform.localScale = Scale;
       // Debug.Log("flipped");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //Debug.Log("Enemy collided with player");
            health.TakeDamage(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Patrol"))
        {
            //Debug.Log("Enemy collided with patrol marker");
            ReverseDirection();
        }
    }

}
