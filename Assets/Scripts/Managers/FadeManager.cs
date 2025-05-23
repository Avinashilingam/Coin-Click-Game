using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 0.5f;

    public IEnumerator FadeIn()
    {
        fadeCanvas.blocksRaycasts = true;
        fadeCanvas.alpha = 1;
        while (fadeCanvas.alpha > 0)
        {
            fadeCanvas.alpha -= Time.deltaTime / fadeDuration;
            yield return null;
        }
        fadeCanvas.blocksRaycasts = false;
    }

    public IEnumerator FadeOut()
    {
        fadeCanvas.blocksRaycasts = true;
        while (fadeCanvas.alpha < 1)
        {
            fadeCanvas.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }
    }
}
