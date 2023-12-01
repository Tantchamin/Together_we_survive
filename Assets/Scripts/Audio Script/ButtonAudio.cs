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
}
