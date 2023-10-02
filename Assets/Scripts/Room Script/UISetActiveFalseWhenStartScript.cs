using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetActiveFalseWhenStartScript : MonoBehaviour
{

    [SerializeField] private GameObject _chooseCharacterLabel;
    [SerializeField] private GameObject _mapLabel;
    [SerializeField] private GameObject _zombieRaid;

    private void Start()
    {
        _chooseCharacterLabel.SetActive(false);
        _mapLabel.SetActive(false);
        _zombieRaid.SetActive(false);
    }

    //hello world;

}
