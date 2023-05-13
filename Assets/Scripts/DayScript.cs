using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DayScript : MonoBehaviour
{
    [SerializeField] private int _maxDaysValue;

    public static event Action OnDayEnd;
    private int _currentDaysValue;
    void Start()
    {
        SetMaxDay(30);
        _currentDaysValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndDay(){
        _currentDaysValue += 1;
    }

    private void SetMaxDay(int _daysValue){
        _maxDaysValue = _daysValue;
    }

    private void GameEnd(){
        if(_currentDaysValue == _maxDaysValue){
            // Do something
        }
    }
}
