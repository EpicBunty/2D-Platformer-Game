using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    // [SerializeField] private Sprite emptyheartsprite;
    [SerializeField] private int MaxHealth;
    [SerializeField] private int PlayerHealth;

    public PlayerController playerController;

    void Start()
    {
        PlayerHealth = MaxHealth;
        RefreshHealthUI();
    }

    public void TakeDamage(int Damage)
    {
        playerController.gameObject.GetComponent<Animator>().SetTrigger("tookdamage");
        PlayerHealth -= Damage;
        SoundManager.Instance.Play(Sounds.PlayerTakeDamage);
        Debug.Log("player health = " + PlayerHealth);

        RefreshHealthUI();

        if (PlayerHealth > MaxHealth)
        { PlayerHealth = MaxHealth; }

        else if (PlayerHealth < 1)
        {
            PlayerHealth = 0;
            playerController.PlayerDead();
            
            //playerController.OpenInGameMenu();
        }
    }

    public int GetPlayerHealth()
    {
        return PlayerHealth;
    }

    void RefreshHealthUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < PlayerHealth)
                hearts[i].gameObject.SetActive(true);
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
   
}
