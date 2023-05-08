using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDayButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject _chooseCharacterLabel;

    public void EndDayButton()
    {
        _chooseCharacterLabel.SetActive(true);
    }
}
