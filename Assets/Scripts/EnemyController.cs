using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float movespeed;
    public Animator animator;
    private bool movingright;
    private bool facingright;
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
        if (gameObject.transform.localScale.x > 0)    
            facingright = true;
                
        else if (gameObject.transform.localScale.x < 0)
            facingright = false;

        Movement();
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
            //Debug.Log("Moving Right");
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

    void Flip()
    {
        Vector3 Scale = transform.localScale;
        if (movingright)
            Scale.x *= -1;
        else /*(!movingright)*/ Scale.x = Mathf.Abs(Scale.x * 1);
        transform.localScale = Scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Enemy collided with player");
            health.TakeDamage(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Patrol"))
        {
            //Debug.Log("Enemy collided with patrol marker");
            Flip();
        }
    }

}
