using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryUIHandler : MonoBehaviour
{
    public void OnLoginButtonPressed()
    {
        GameManager.instance.sceneLoader.LoadSceneWithLoading("LoginScene");
    }
}
