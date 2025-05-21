using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    public Image progressBar;

    void Start()
    {
        StartCoroutine(FakeProgress());
    }

    private IEnumerator FakeProgress()
    {
        float duration = 1.5f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            progressBar.fillAmount = Mathf.Clamp01(timer / duration);
            yield return null;
        }
    }
}
