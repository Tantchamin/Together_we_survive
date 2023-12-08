using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireAudio : MonoBehaviour
{
    [SerializeField] private GameObject bonfireCheck1, bonfireCheck2, bonfireCheck3;
    [SerializeField] private GameObject gameCamera;
    [SerializeField] private AudioSource bonfireSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bonfireCheck1.activeSelf == false && bonfireCheck2.activeSelf == false && bonfireCheck3.activeSelf == false && gameCamera.transform.position.x == 0)
        {
            bonfireSource.volume = 1;
        }
        else
        {
            bonfireSource.volume = 0;
        }
    }
}
