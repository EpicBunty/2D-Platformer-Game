using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteMenu : MonoBehaviour
{
    public Button Continue;

    private void Awake()
    {
        //LevelManager.Instance.Init();
        Continue.onClick.AddListener(LevelManager.Instance.LoadNextScene);

    }
}
