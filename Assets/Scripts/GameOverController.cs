using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    private int CurrentScene;
    public int LastScene;
    //private int PreviousScene;
    public Button restartButton;
    public Button mainMenuButton;

    LevelController levelController;

    private void Awake()
    {
        
        levelController = gameObject.GetComponent<LevelController>();
        CurrentScene = SceneManager.GetActiveScene().buildIndex;

        restartButton.onClick.AddListener(levelController.ReloadLevel);
        mainMenuButton.onClick.AddListener(levelController.LoadLobby);
        
    }




    public void InGameMenu(bool OnorOff)
    {
        gameObject.SetActive(OnorOff);
    }
        /*if (CurrentScene != 0)
        {
            LastScene = CurrentScene;
        }
    }*/
}
