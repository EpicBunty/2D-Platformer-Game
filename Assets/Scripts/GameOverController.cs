using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour
{
    /*private int CurrentScene;
    public int LastScene;*/
    //private int PreviousScene;
    public Button restartButton;
    public Button mainMenuButton;

    //LevelController levelController;

    private void Awake()
    {
        //restartButton.onClick.AddListener(LevelManager.Instance.ReloadLevel);
        //mainMenuButton.onClick.AddListener(LevelManager.Instance.LoadLobby);

        restartButton.onClick.AddListener(ReloadLevel);
        mainMenuButton.onClick.AddListener(MainMenu);

    }

    public void ReloadLevel()
    {
        //Debug.Log("reload level called from level manager");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        //Debug.Log("loading main menu from level manager");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
