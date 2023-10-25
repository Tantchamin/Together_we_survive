using UnityEngine;
using System;
public class DayManagerScript : MonoBehaviour
{
    [SerializeField] MapSelectScript mapSelectScript;
    [SerializeField] private static byte day = 1;
    [SerializeField] private static byte maxDays = 31; 
    public static event Action OnDayEnd = delegate{};
    public static event Action OnDayStart = delegate{};
    public static event Action OnMaxDay ; 
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
        Debug.Log($"Current days : {day}");
        day +=1;
        if(day >= maxDays)
        {
            OnMaxDay?.Invoke();
            return;
        }
        OnDayEnd();
        SetDayState();
        DayStart();
    }

    public static void DayStart()
    {
        OnDayStart();    
    }

    public static byte GetDays()
    {
        return day;
    }
    public static byte GetMaxDays()
    {
        return maxDays;
    }

    public static DayAmountState GetDaysState()
    {
        return dayAmountState;
    }

}
