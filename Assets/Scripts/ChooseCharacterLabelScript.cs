using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterLabelScript : MonoBehaviour
{
    [SerializeField] private GameObject _mapLabel;
    ChooseCharacterManagerScript _chooseCharacterManagerScript;

    private void Start()
    {
        _chooseCharacterManagerScript = GameObject.FindGameObjectWithTag("ChooseCharacterManager").GetComponent<ChooseCharacterManagerScript>();
        
    }

    public void NextButton()
    {
        if (_chooseCharacterManagerScript.IsHaveScavenger() == true)
        {
            _mapLabel.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
