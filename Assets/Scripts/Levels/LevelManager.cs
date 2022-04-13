using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    //public string Level1;

    private Scene CurrentScene;
    private Scene NextScene;

    public int CurrentSceneIndex;
    public int NextSceneIndex;

    public string[] Levels;

    //public string level;
    public static LevelManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        Init();
        /*CurrentScene = SceneManager.GetActiveScene();
        CurrentSceneIndex = Array.FindIndex(Levels, level => level == CurrentScene.name);
        NextSceneIndex = CurrentSceneIndex + 1;*/
    }

    private void Start()
    {
        /*string Level1 = "Level1";
         * 
        if (GetLevelStatus(Level1) == LevelStatus.Locked)
        {
            SetLevelStatus(Level1, LevelStatus.Unlocked);
        }*/

        /*if (GetLevelStatus(Levels[1]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[1], LevelStatus.Unlocked);
        }*/

        if (GetLevelStatus(1) == LevelStatus.Locked)
        {
            SetLevelStatus(1, LevelStatus.Unlocked);
        }
    }
    public void Init()
    {
        /*CurrentScene = SceneManager.GetActiveScene();
        CurrentSceneIndex = Array.FindIndex(Levels, level => level == CurrentScene.name);//SceneManager.GetActiveScene().buildIndex;
        NextSceneIndex = CurrentSceneIndex + 1;
        NextScene = SceneManager.GetSceneByBuildIndex(NextSceneIndex);*/

        CurrentScene = SceneManager.GetActiveScene();
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        NextSceneIndex = CurrentSceneIndex + 1;
        NextScene = SceneManager.GetSceneByBuildIndex(NextSceneIndex);

        Debug.Log("Current Scene is " + CurrentScene.name);
        Debug.Log("Next Scene is " + NextScene.name);
        //Debug.Log("Next Scene is " + SceneManager.GetSceneByBuildIndex(NextSceneIndex).name;
    }

    /* public LevelStatus GetLevelStatus(string level)
     {
         LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
         return levelStatus;
     }*/

    public LevelStatus GetLevelStatus(int level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(Levels[level], 0);
        return levelStatus;
    }

    /* public void SetLevelStatus(string level, LevelStatus levelStatus)
     {
         PlayerPrefs.SetInt(level, (int)levelStatus);
         Debug.Log("setting level " + level + " status to " + levelStatus);
         Init();
     }*/

    public void SetLevelStatus(int level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(Levels[level], (int)levelStatus);
        Debug.Log("setting level " + level + " status to " + levelStatus);
        Init();
    }

    /*public void MarkCurrentLevelComplete()
    {
        SetLevelStatus(CurrentScene.name, LevelStatus.Completed);
    }*/

    public void MarkCurrentLevelComplete()
    {
        SetLevelStatus(CurrentSceneIndex, LevelStatus.Completed);
    }

    /* public void MarkNextLevelUnlocked()
     { 
         if (NextSceneIndex < Levels.Length)
         {
             SetLevelStatus(Levels[NextSceneIndex], LevelStatus.Unlocked);
         }
         //SetLevelStatus(NextScene.name, LevelStatus.Unlocked);
     }*/

    public void MarkNextLevelUnlocked()
    {
        SetLevelStatus(NextSceneIndex, LevelStatus.Unlocked);
    }

    public void LoadNextScene()
    {
        //Init();
        Debug.Log("level manager is loading next scene which is " + NextScene.name);
        SceneManager.LoadScene(NextSceneIndex);
    }
}
