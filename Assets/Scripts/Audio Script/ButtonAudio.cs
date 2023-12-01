using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    [SerializeField] private AudioSource buttonSource;

    public void PlayButtonAudio()
    {
        buttonSource.Play();
    }
}
