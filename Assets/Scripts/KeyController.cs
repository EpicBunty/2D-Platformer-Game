using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyController : MonoBehaviour 
{
    private ScoreController Score;
    
    private void Start()
    {
        Score = FindObjectOfType<ScoreController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            //if (collision.gameObject.tag == "Player")
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("key collided with player");
            
            Score.ScoreIncrement(10);
            //ScoreController.ScoreIncrement(10);
            Destroy(gameObject);
        }
    }




}