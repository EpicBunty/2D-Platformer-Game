using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    //public string LevelName;
    public int LevelIndex;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }

    /*private void LoadLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level Locked");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;
        }

        
    }*/

    private void LoadLevel()
    {
        LevelManager.Instance.Init();
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelIndex);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level Locked");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelIndex);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelIndex);
                break;
        }


    }

}

