using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button ButtonContinue;
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonBack;
    [SerializeField] private Button buttonQuit;
    [SerializeField] private GameObject LevelSelectionMenu;
    //private int CurrentScene;
    //public GameOverController gameOverController;
    //LevelController levelController;


    private void Awake()
    {
        

        buttonPlay.onClick.AddListener(PlayGame);
        buttonBack.onClick.AddListener(GoBack);
        buttonQuit.onClick.AddListener(QuitGame);

        //buttonQuit.onClick.AddListener(LevelManager.Instance.QuitGame);
        //ButtonContinue.onClick.AddListener(ContinueGame);

        /*if (levelController.LastScene != 0)
        {
            ButtonContinue.gameObject.SetActive(true);
        }
        else ButtonContinue.gameObject.SetActive(false);*/

        //ButtonContinue.gameObject.SetActive(levelController.lastscene);
    }

    public void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelectionMenu.SetActive(true);
    }
    /*public void ContinueGame()
    {
        SceneManager.LoadScene(levelController.LastScene);
    }*/

    void GoBack()
    {
        SoundManager.Instance.Play(Sounds.ButtonBack);
        LevelSelectionMenu.SetActive(false);
    }

    public void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonBack);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
