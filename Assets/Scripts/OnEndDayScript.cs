using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEndDayScript : MonoBehaviour
{

    [SerializeField] private CharacterStatScript _father, _mother, _sister, _brother;

    private void Start()
    {
        _father = GameObject.FindWithTag("Father").GetComponent<CharacterStatScript>();
        _mother = GameObject.FindWithTag("Mother").GetComponent<CharacterStatScript>();
        _sister = GameObject.FindWithTag("Sister").GetComponent<CharacterStatScript>();
        _brother = GameObject.FindWithTag("Brother").GetComponent<CharacterStatScript>();
    }

    public void OnEndDayButtonClick()
    {
        _father.CharacterHungryAdjust(-2);
        _mother.CharacterHungryAdjust(-2);
        _sister.CharacterHungryAdjust(-2);
        _brother.CharacterHungryAdjust(-2);
        //_father.CharacterHealthAdjust(-2);
        //_mother.CharacterHealthAdjust(-2);
        //_sister.CharacterHealthAdjust(-2);
        //_brother.CharacterHealthAdjust(-2);

    }
}
