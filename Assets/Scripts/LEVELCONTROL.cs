using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LEVELCONTROL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReloadLevel()
    {
        string currentscene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentscene);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void LoadNextScene()
    {
        int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("loading scene " + NextScene);
        SceneManager.LoadScene(NextScene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
