using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterLabelScript : MonoBehaviour
{
    [SerializeField] private GameObject _mapLabel;

    public void NextButton()
    {
        _mapLabel.SetActive(false);
        gameObject.SetActive(false);
    }
}
