/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static LevelManager instance;
    public int CurrentScene;
    private static int scenetocontinue;
    public int LastScene { get { return scenetocontinue; } }
   
    private int NextScene;
    
    private void Awake()
    {
        //NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
        if (CurrentScene != 0)
        {
            scenetocontinue = CurrentScene;
        }
    }

    *//*public void InGameMenu(bool IsActive)
    {
        gameObject.SetActive(IsActive);

        if (CurrentScene != 0)
        {
            LastScene = CurrentScene;
        }
    }*//*

    public void ReloadLevel()
    {
        Debug.Log("reload level called from level controller");
        //CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
    }

    public void LoadNextScene()
    {
        NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("level controller is loading next scene which is " + NextScene);
        SceneManager.LoadScene(NextScene);
    }

    public void LoadLobby()
    {
        Debug.Log("loading lobby from level controller");
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
*/