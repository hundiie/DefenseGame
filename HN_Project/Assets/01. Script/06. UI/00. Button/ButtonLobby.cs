using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLobby : MonoBehaviour
{
    public void Button_GameStart(string SceneName)
    {
        SceneLoad.LoadScene(SceneName);
    }
}
