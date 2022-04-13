using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    //SerializeField
   [SerializeField] ScoreController scoreController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            scoreController.ScoreIncrement(10);
            gameObject.SetActive(false);
        }
    }
}
