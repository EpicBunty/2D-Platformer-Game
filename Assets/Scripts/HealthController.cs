using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private int MaxHealth;
    private int PlayerHealth;
    LEVELCONTROL level;
    //private int Health;
    void Start()
    {
        level = GetComponent<LEVELCONTROL>();
        //MaxHealth = 3;
        PlayerHealth = MaxHealth;
        RefreshHealthUI();
    }

    public void TakeDamage(int Damage)
    {
        PlayerHealth -= Damage;
        Debug.Log("player health = " + PlayerHealth);
        RefreshHealthUI(); 
        /*if (PlayerHealth > 0)
        else
        {
            //level.ReloadLevel();

        }*/


    }

    void RefreshHealthUI()
    {
        //for (int i = 0; i < hearts.Length; i++)
        for (int i = 0; i < MaxHealth; i++)
        {
            if (i < PlayerHealth)
                hearts[i].gameObject.SetActive(true);
            else
                hearts[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (PlayerHealth > MaxHealth)
            PlayerHealth = MaxHealth;
        else if (PlayerHealth < 1)
            level.ReloadLevel();
    }
}
