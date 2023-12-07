using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    [SerializeField] private List<AudioSource> buttonSource;

    public void PlayButtonAudio()
    {
        buttonSource[0].Play();
    }

    public void PlayChangeRoomAudio()
    {
        buttonSource[1].Play();
    }

    public void PlayCloseButtonAudio()
    {
        buttonSource[2].Play();
    }

    public void PlayCraftAudio()
    {
        buttonSource[3].Play();
    }

    public void PlayFireLitAudio()
    {
        buttonSource[4].Play();
    }

    public void PlayEatAudio()
    {
        buttonSource[5].Play();
    }

    public void PlayDrinkAudio()
    {
        buttonSource[6].Play();
    }
}
