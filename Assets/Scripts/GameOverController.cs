using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private int currentscene;
    private int NextScene;
    public Button restartButton;
    public Button mainMenuButton;
    private void Awake()
    {
        //NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        //currentscene = SceneManager.GetActiveScene().buildIndex;
        restartButton.onClick.AddListener(ReloadLevel);
        mainMenuButton.onClick.AddListener(LoadLobby);
    }

    /*private void Update()
    {
        Input.GetButtonDown("cancel");
    }*/

    public void InGameMenuActive()
    {
        gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        Debug.Log("reload level called");
        currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
    }

    public void LoadNextScene()
    {
        NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("loading next scene " + NextScene);
        SceneManager.LoadScene(NextScene);
    }

    public void LoadLobby()
    {
        //int PreviousScene = SceneManager.LoadScene(0);
        Debug.Log("loading lobby");
        SceneManager.LoadScene(0,LoadSceneMode.Single);
        
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
