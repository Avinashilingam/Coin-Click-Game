using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public void PlayMusic(AudioClip clip, float fadeDuration = 1f)
    {
        StartCoroutine(FadeInMusic(clip, fadeDuration));
    }

    public void StopMusic(float fadeDuration = 1f)
    {
        StartCoroutine(FadeOutMusic(fadeDuration));
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    private IEnumerator FadeInMusic(AudioClip clip, float duration)
    {
        if (clip == null) yield break;

        musicSource.clip = clip;
        musicSource.volume = 0;
        musicSource.Play();

        float time = 0;
        while (time < duration)
        {
            musicSource.volume = Mathf.Lerp(0f, 1f, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        musicSource.volume = 1f;
    }

    private IEnumerator FadeOutMusic(float duration)
    {
        float startVolume = musicSource.volume;

        float time = 0;
        while (time < duration)
        {
            musicSource.volume = Mathf.Lerp(startVolume, 0f, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume;
    }
}
