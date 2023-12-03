using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAmbientSound : MonoBehaviour
{
    [SerializeField] private int ambientRate;
    private bool isMorning = true;
    private float timeCount = 0;
    [SerializeField] private List<AudioSource> zombieAmbientList;

    private void Start()
    {
        InvokeRepeating("ZombieAmbientPlay", ambientRate, ambientRate);
    }

    private void Update()
    {
        //timeCount += Time.deltaTime;
        //Debug.Log(Mathf.Floor(timeCount));

        //if(Mathf.Floor(timeCount) == ambientRate)
        //{
        //    timeCount = 0;
        //    if (isMorning)
        //    {
        //        RandomZombieAmbient();
        //    }
        //    Debug.Log("Time Reset");
        //}

    }

    void ZombieAmbientPlay()
    {
        if (isMorning)
        {
            RandomZombieAmbient();
        }
    }

    void RandomZombieAmbient()
    {
        int randomNumber = Random.Range(0, zombieAmbientList.Count);
        zombieAmbientList[randomNumber].Play();
        Debug.Log("Play zombie sound: " + zombieAmbientList[randomNumber]);
    }

    public void ChangeIsMornnigState(bool isTrue)
    {
        isMorning = isTrue;
        Debug.Log("IsMorning state: " + isMorning);
    }
}
