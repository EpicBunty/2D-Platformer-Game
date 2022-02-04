using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite emptyheartsprite;
    [SerializeField] private int MaxHealth;
    [SerializeField] private int PlayerHealth;
    public GameOverController level;
    public PlayerController playerController;
    //Animator animator;
    //private int Health;
    void Start()
    {
        PlayerHealth = MaxHealth;
        RefreshHealthUI();

        //animator = gameObject.GetComponent<Animator>();
        //Debug.Log("player health = " + PlayerHealth);
    }

    public void TakeDamage(int Damage)
    {
        PlayerHealth -= Damage;
        Debug.Log("player health = " + PlayerHealth);
        RefreshHealthUI();
        if (PlayerHealth > MaxHealth)
            PlayerHealth = MaxHealth;
        else if (PlayerHealth < 1)
        {
            PlayerHealth = 0;
            //level.PlayerDead();
            playerController.OpenInGameMenu();
        }
    }

    void RefreshHealthUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < PlayerHealth)
                hearts[i].gameObject.SetActive(true);
            //hearts[i].gameObject.GetComponent<Image>().sprite = emptyheartsprite;
            else
            {
               hearts[i].gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        
    }
}
