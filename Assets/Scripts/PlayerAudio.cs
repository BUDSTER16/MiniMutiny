using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("SFX")]
    [SerializeField] private AudioClip pickup;
    [SerializeField] private AudioClip lever;
    [SerializeField] private AudioClip warn;
    [SerializeField] private AudioClip ohno;
    [SerializeField] private AudioClip button;

    private AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "pickup":
                audioPlayer.clip = pickup;
                audioPlayer.Play();
                break;
            case "lever":
                audioPlayer.clip = lever;
                audioPlayer.Play();
                break;
            case "warn":
                audioPlayer.clip = warn;
                audioPlayer.Play();
                break;
            case "ohno":
                audioPlayer.clip = ohno;
                audioPlayer.Play();
                break;
            case "button":
                audioPlayer.clip = button;
                audioPlayer.Play();
                break;
        }
    }
}
