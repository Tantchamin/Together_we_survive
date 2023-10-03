using UnityEngine;
using System;
public class DayManagerScript : MonoBehaviour
{
    [SerializeField] MapSelectScript mapSelectScript;
    [SerializeField] private int day = 1;
    public event Action OnDayEnd = delegate{};
    public event Action OnDayStart = delegate{};

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

}
