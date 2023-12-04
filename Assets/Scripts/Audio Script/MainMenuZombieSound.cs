using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuZombieSound : MonoBehaviour
{
    [SerializeField] private List<AudioSource> zombieAmbientList;

    private void Start()
    {
        InvokeRepeating("ZombieAmbientPlay", 4, 18);
    }

    void ZombieAmbientPlay()
    {
        int randomNumber = Random.Range(0, zombieAmbientList.Count);
        zombieAmbientList[randomNumber].Play();
        Debug.Log("Play zombie sound: " + zombieAmbientList[randomNumber]);
    }
}
