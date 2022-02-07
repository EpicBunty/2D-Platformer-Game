using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button ButtonContinue;
    public Button buttonPlay;
    public Button buttonQuit;
    //private int CurrentScene;
    //public GameOverController gameOverController;
    LevelController levelController;


    private void Awake()
    {
        levelController = gameObject.GetComponent<LevelController>();
        //gameOverController = gameObject.GetComponent<GameOverController>();
        //buttonPlay.onClick.AddListener(levelController.LoadNextScene);
        buttonQuit.onClick.AddListener(QuitGame);
        ButtonContinue.onClick.AddListener(ContinueGame);

        if (levelController.LastScene != 0)
        {
            ButtonContinue.gameObject.SetActive(true);
        }
        else ButtonContinue.gameObject.SetActive(false);

        //ButtonContinue.gameObject.SetActive(levelController.lastscene);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(levelController.LastScene);
    }

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    /*public void LoadNextScene()
    {
        int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("loading scene " + NextScene);
        SceneManager.LoadScene(NextScene);
    }*/

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
