using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingScreenScript : MonoBehaviour
{
    public string SceneName;
    private Slider slider;
    private AsyncOperation asyncOperation;
    public bool haveChosenColor = false;
    public Color chosenColor;
    public float timeToLoad;
    public float currentTimeToLoad = 0f;
    public playerConfig playerConfig1;
    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync(SceneName);
        asyncOperation.allowSceneActivation = false;
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        currentTimeToLoad += Time.deltaTime;
        if (currentTimeToLoad > timeToLoad) currentTimeToLoad = timeToLoad;
        slider.value = asyncOperation.progress - (timeToLoad/currentTimeToLoad) + 1f;
        if (asyncOperation.progress >= 0.9f && slider.value == slider.maxValue && haveChosenColor) StartCoroutine("startScene");
    }

    IEnumerator startScene()
    {
        yield return new WaitForSeconds(2f);
        asyncOperation.allowSceneActivation = true;
    }

    public void ChooseColor(int color)
    {
        switch (color)
        {
            case 0:
                chosenColor = Color.red;
                break;
            case 1:
                chosenColor = Color.blue;
                break;
        }
        playerConfig1.playerColor = chosenColor;
        haveChosenColor = true;
    }
}
