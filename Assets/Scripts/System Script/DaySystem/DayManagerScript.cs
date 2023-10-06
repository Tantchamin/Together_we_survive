using UnityEngine;
using System;
public class DayManagerScript : MonoBehaviour
{
    [SerializeField] MapSelectScript mapSelectScript;
    [SerializeField] private static int day = 1;
    public static event Action OnDayEnd = delegate{};
    public static event Action OnDayStart = delegate{};
    [SerializeField] private static DayAmountState dayAmountState;
    public enum DayAmountState
    {
        earlyDays ,
        midDays,
        lateDays,
        finalDays
    }

    private static void SetDayState()
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
    public static void IncreaseDays()
    {
        Debug.Log($"Current days {day}");
        day +=1;
        OnDayEnd();
        SetDayState();
        DayStart();
    }

    public static void DayStart()
    {
        OnDayStart();    
    }

    public static int GetDays()
    {
        return day;
    }

    public static DayAmountState GetDaysState()
    {
        return dayAmountState;
    }

}
