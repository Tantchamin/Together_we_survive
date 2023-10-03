  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetActiveFalseWhenStartScript : MonoBehaviour
{

    [SerializeField] private GameObject chooseCharacterLabel;
    [SerializeField] private GameObject mapLabel;
    [SerializeField] private GameObject zombieRaidUI;

    private void Start()
    {
        chooseCharacterLabel.SetActive(false);
        mapLabel.SetActive(false);
    }

    //hello world;

}
