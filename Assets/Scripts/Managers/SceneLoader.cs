using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneWithLoading(string targetScene)
    {
        StartCoroutine(LoadSceneRoutine(targetScene));
    }

    private IEnumerator LoadSceneRoutine(string targetScene)
    {
        // Load the loading screen scene
        AsyncOperation loadOp = SceneManager.LoadSceneAsync("LoadingScene");
        while (!loadOp.isDone) yield return null;

        // Simulate loading delay (e.g. fake progress bar)
        yield return new WaitForSeconds(1.5f);

        // Load the actual target scene
        AsyncOperation targetOp = SceneManager.LoadSceneAsync(targetScene);
        Debug.Log($"Loading {targetScene}...");
        // Optionally, you can set the loading screen to be the active scene
        while (!targetOp.isDone) yield return null;
    }
}
