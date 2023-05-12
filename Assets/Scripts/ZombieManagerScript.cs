using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManagerScript : MonoBehaviour
{
    [SerializeField] private DayManagerScript dayManagerScript;
    [SerializeField] private GameObject _zombieRaidUI;
    private int _day;

    void Start()
    {
        _zombieRaidUI.SetActive(false);
        dayManagerScript.GetComponent<DayManagerScript>();
    }

    public void ZombieRaidChanceAfterEndDay()
    {
        _day = dayManagerScript.GetDay();

        if(_day >= 2 && _day <= 7)
        {
            RandomChance(20);
        } 
        else if(_day >= 8 && _day <= 14)
        {
            RandomChance(30);
        }
        else if (_day >= 15 && _day <= 21)
        {
            RandomChance(40);
        }
        else if (_day >= 22 && _day <= 29)
        {
            RandomChance(50);
        }
        else if (_day == 30)
        {
            RandomChance(100);
        }
    } 

    void RandomChance(int appearChance)
    {
        int randomNumber = Random.Range(1, 101);
        Debug.Log("Random chance: " + randomNumber + " , Appear chance: " + appearChance);
        if(randomNumber <= appearChance)
        {
            _zombieRaidUI.SetActive(true);
        }

    }
}
