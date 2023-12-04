using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCutscene : MonoBehaviour
{
    [SerializeField] private GameObject storyCamera;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeCameraPosition", 2.30f , 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeCameraPosition()
    {
        if(count < 5)
        {
            storyCamera.transform.position += new Vector3(25, 0, 0);
            count++;
        }
    }
}
