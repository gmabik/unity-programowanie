using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string loadingScreenScene;
    public void StartLoadingScreen()
    {
        SceneManager.LoadSceneAsync("SceneManager");
        SceneManager.LoadScene(loadingScreenScene);
    }
}
