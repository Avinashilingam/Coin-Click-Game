using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            sceneLoader = GetComponent<SceneLoader>();
            audioManager = GetComponent<AudioManager>();
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
