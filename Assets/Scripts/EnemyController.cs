using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    [SerializeField] private float movespeed;
    //[SerializeField] private bool facingright;
    [SerializeField] private float DirectionFacing;

    //private bool movingright;
    //private Rigidbody2D rb;
    //private Vector2 Scale;
    [SerializeField] private HealthController health;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        //rb = gameObject.GetComponent<Rigidbody2D>();
        DirectionFacing = gameObject.transform.localScale.x;
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 move = transform.position;
        move.x = move.x + DirectionFacing * Time.deltaTime * movespeed;
        transform.position = move;
        animator.SetFloat("speed", movespeed);
    }
    private void ChomperMoveSound()
    {
        SoundManager.Instance.Play(Sounds.ChomperWalk);
    }

    private void ChomperRunSound()
    {
        SoundManager.Instance.Play(Sounds.ChomperRun);
    }
    void ReverseDirection()
    {
        Vector3 Scale = transform.localScale;

        DirectionFacing *= -1;
        Scale.x = DirectionFacing;
        transform.localScale = Scale;
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
