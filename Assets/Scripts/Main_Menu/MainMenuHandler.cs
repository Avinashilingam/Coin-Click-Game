using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        GameManager.instance.sceneLoader.LoadSceneWithLoading("GameScene");
    }
    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
