using UnityEngine;
using System;
public class DayManagerScript : MonoBehaviour
{
    [SerializeField] MapSelectScript mapSelectScript;
    [SerializeField] private int day = 1;
    public event Action OnDayEnd = delegate{};
    public event Action OnDayStart = delegate{};
    [SerializeField] private DayAmountState dayAmountState;
    public enum DayAmountState
    {
        earlyDays ,
        midDays,
        lateDays,
        finalDays
    }

    private void SetDayState()
    {
        dayAmountState = (day <= 10 && day >0) ? dayAmountState = DayAmountState.earlyDays :
        (day > 11 && day <= 20) ? dayAmountState = DayAmountState.midDays :
        (day > 21 && day <= 29) ? DayAmountState.lateDays : DayAmountState.finalDays;
    }


    private void Awake() 
    {
        mapSelectScript = FindObjectOfType<MapSelectScript>();
        // mapSelectScript.OnDayStart += DayStart;
    }
    public void IncreaseDays()
    {
        Debug.Log($"Current days {day}");
        day +=1;
        OnDayEnd();
        SetDayState();
        DayStart();
    }

    public void DayStart()
    {
        OnDayStart();    
    }

    public int GetDays()
    {
        return day;
    }

    public DayAmountState GetDaysState()
    {
        return this.dayAmountState;
    }

}
