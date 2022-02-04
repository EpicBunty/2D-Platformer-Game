using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button buttonPlay;
    public Button buttonQuit;
    //public GameOverController gameOverController;

    private void Awake()
    {
        //gameOverController = gameObject.GetComponent<GameOverController>();
        buttonPlay.onClick.AddListener(LoadNextScene);
        buttonQuit.onClick.AddListener(QuitGame);
    }

    public void LoadNextScene()
    {
        int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("loading scene " + NextScene);
        SceneManager.LoadScene(NextScene);
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
