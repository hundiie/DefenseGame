using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTitle : MonoBehaviour
{
    public GameObject Setting_UI;

    public void Button_SceneLoad(string SceneName)
    {
        SceneLoad.LoadScene(SceneName);
    }
    public void Button_Setting(bool Set)
    {
        Setting_UI.SetActive(Set);
    }
    public void Button_Exit()
    {
        Application.Quit();
    }


}
