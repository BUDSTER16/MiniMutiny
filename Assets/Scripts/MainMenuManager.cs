using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject musicMachine;
    private void Start()
    {
        DontDestroyOnLoad(musicMachine);
    }
    public void Play()
    {
        SceneManager.LoadScene("Intro");
    }
}
