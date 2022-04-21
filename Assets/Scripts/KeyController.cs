using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    //SerializeField
   [SerializeField] UITextController UItextcontroller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            SoundManager.Instance.Play(Sounds.Collectible);
            UItextcontroller.ScoreIncrement(10);
            gameObject.SetActive(false);
        }
    }
}
