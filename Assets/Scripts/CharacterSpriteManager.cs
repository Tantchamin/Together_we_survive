using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteManager : MonoBehaviour
{
    [SerializeField] private CharacterStatScript characterStatScript;
    [SerializeField] private GameObject _injuredSprite, _tiredSprite, _sickSprite, _infectedSprite, _hungrySprite, _thirstySprite;

    private void Start()
    {
        characterStatScript = GetComponent<CharacterStatScript>();
    }

    private void Update()
    {
        if (characterStatScript.GetHungry() == true)
        {
            _hungrySprite.SetActive(true);
        }
        else
        {
            _hungrySprite.SetActive(false);
        }

        if (characterStatScript.GetThirsty() == true)
        {
            _thirstySprite.SetActive(true);
        }
        else
        {
            _thirstySprite.SetActive(false);
        }

        if (characterStatScript.GetInjured() == true)
        {
            _injuredSprite.SetActive(true);
        }
        else
        {
            _injuredSprite.SetActive(false);
        }

        if (characterStatScript.GetTired() == true)
        {
            _tiredSprite.SetActive(true);
        }
        else
        {
            _tiredSprite.SetActive(false);
        }

        if (characterStatScript.GetSick() == true)
        {
            _sickSprite.SetActive(true);
        }
        else
        {
            _sickSprite.SetActive(false);
        }

        if (characterStatScript.GetInfected() == true)
        {
            _infectedSprite.SetActive(true);
        }
        else
        {
            _infectedSprite.SetActive(false);
        }
    }
}
