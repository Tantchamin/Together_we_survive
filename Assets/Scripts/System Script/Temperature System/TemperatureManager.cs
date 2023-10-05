using System;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    [SerializeField] private byte temperature = 25;
    private byte currentDays = 0;
    private DayManagerScript dayManagerScript;

    public event Action<byte> OnTemperatureChanged;

    private void Awake() 
    {
        dayManagerScript = FindObjectOfType<DayManagerScript>();
        dayManagerScript.OnDayEnd += NextDayTemperature;
        OnTemperatureChanged?.Invoke(temperature);
    }

    private void OnDisable() 
    {
        dayManagerScript.OnDayEnd -= NextDayTemperature;
    }

    private void NextDayTemperature()
    {
        currentDays = (byte) dayManagerScript.GetDays();
        TemperatureCondition();
    }

    private void TemperatureCondition()
    {
        if(dayManagerScript.GetDaysState() == DayManagerScript.DayAmountState.earlyDays)
        {
            SetNextDayTemperature(RandomNextDayTemperature(22,28));
        }
        else if(dayManagerScript.GetDaysState() == DayManagerScript.DayAmountState.midDays)
        {
            SetNextDayTemperature(RandomNextDayTemperature(15,23));
        }
        else if(dayManagerScript.GetDaysState() == DayManagerScript.DayAmountState.lateDays)
        {
            SetNextDayTemperature(RandomNextDayTemperature(10,18));
        }
        else
        {
            SetNextDayTemperature(RandomNextDayTemperature(18,18));
        }
    }

    private byte RandomNextDayTemperature(byte _lowestTemperature , byte _highestTemperature)
    {
        byte _randomTemperature = (byte)UnityEngine.Random.Range(_lowestTemperature , _highestTemperature);

        return _randomTemperature;
    }

    private void SetNextDayTemperature(byte newTemperature)
    {
        temperature = newTemperature;
        OnTemperatureChanged?.Invoke(temperature);
    }
    public byte GetTemperature()
    {
        return temperature;
    }
}
