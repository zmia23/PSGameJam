using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAudioSource : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip mainMenuAudioClip;
    [SerializeField] private AudioClip gameplayAudioClip;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayMainMenuMusic()
    {
        SetAudioSourceClip(mainMenuAudioClip);
    }
    public void PlayGameplayMusic()
    {
        SetAudioSourceClip(gameplayAudioClip);
    }
    private void SetAudioSourceClip(AudioClip clipToSet)
    {
        audioSource.clip = clipToSet;
        audioSource.Play();
    }
    private void StopAudioSource()
    {
        audioSource.Stop();
    }
}
