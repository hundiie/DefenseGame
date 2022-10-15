using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    Slider loadingBar;
    Text LoadingText;

    static string SCENE;
    private void Start()
    {
        loadingBar = transform.GetChild(1).GetComponent<Slider>();
        LoadingText = transform.GetChild(2).GetComponent<Text>();
        loadingBar.value = 0;
        StartCoroutine(LoadText());
        StartCoroutine(LoadAsyncScene(SCENE));
    }
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Load");
        SCENE = sceneName;
    }
    private IEnumerator LoadText()
    {
        while(true)
        {
            LoadingText.text = "Loading";
            yield return new WaitForSeconds(0.1f);
            LoadingText.text = "Loading .";
            yield return new WaitForSeconds(0.1f);
            LoadingText.text = "Loading . .";
            yield return new WaitForSeconds(0.1f);
            LoadingText.text = "Loading . . .";
            yield return new WaitForSeconds(0.1f);
            LoadingText.text = "Loading . .";
            yield return new WaitForSeconds(0.1f);
            LoadingText.text = "Loading .";
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator LoadAsyncScene(string SceneName)
    {
        yield return null;
        AsyncOperation asyncScene = SceneManager.LoadSceneAsync(SceneName);
        asyncScene.allowSceneActivation = false;
        float timeC = 0;
        while (!asyncScene.isDone)
        {
            yield return null;
            timeC += Time.deltaTime;
            if (asyncScene.progress >= 0.9f)
            {
                loadingBar.value = Mathf.Lerp(loadingBar.value, 1, timeC);
                if (loadingBar.value == 1.0f)
                {
                    asyncScene.allowSceneActivation = true;
                }
            }
            else
            {
                loadingBar.value = Mathf.Lerp(loadingBar.value, asyncScene.progress, timeC);
                if (loadingBar.value >= asyncScene.progress)
                {
                    timeC = 0f;
                }
            }
        }
    }
}
