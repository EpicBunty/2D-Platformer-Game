using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyController : MonoBehaviour 
{
    public ScoreController scoreController;


    private void OnTriggerEnter2D(Collider2D collision)
    {
            //if (collision.gameObject.tag == "Player")
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            scoreController.ScoreIncrement(10);
            //ScoreController.ScoreIncrement(10);
            Destroy(gameObject);
        }
    }




}