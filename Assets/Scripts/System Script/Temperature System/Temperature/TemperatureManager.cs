using System;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    [SerializeField] private float temperature = 25.0f;
    public float Temperature
    {
        get => temperature;
        set {
            temperature = value;
            OnTemperatureChanged?.Invoke(temperature);
            
        }
    }
    private byte currentDays = 0;
    private DayManagerScript DayManagerScript;

    public event Action<float> OnTemperatureChanged;

    private void Awake() 
    {
        
        DayManagerScript.OnDayEnd += NextDayTemperature;
        OnTemperatureChanged?.Invoke(temperature);
    }

    private void OnDisable() 
    {
        DayManagerScript.OnDayEnd -= NextDayTemperature;
    }

    private void NextDayTemperature()
    {
        currentDays = (byte) DayManagerScript.GetDays();
        TemperatureCondition();
    }

    private void TemperatureCondition()
    {
        if(DayManagerScript.GetDaysState() == DayManagerScript.DayAmountState.earlyDays)
        {
            SetNextDayTemperature(RandomNextDayTemperature(22.0f,28.0f));
        }
        else if(DayManagerScript.GetDaysState() == DayManagerScript.DayAmountState.midDays)
        {
            SetNextDayTemperature(RandomNextDayTemperature(15.0f,23.0f));
        }
        else if(DayManagerScript.GetDaysState() == DayManagerScript.DayAmountState.lateDays)
        {
            SetNextDayTemperature(RandomNextDayTemperature(10.0f,18.0f));
        }
        else
        {
            SetNextDayTemperature(RandomNextDayTemperature(18,18));
        }
    }

    private float RandomNextDayTemperature(float _lowestTemperature , float _highestTemperature)
    {
        float _randomTemperature = UnityEngine.Random.Range(_lowestTemperature , _highestTemperature);

        return _randomTemperature;
    }

    private void SetNextDayTemperature(float newTemperature)
    {
        Temperature = newTemperature;
    }
    public float GetTemperature()
    {
        return temperature;
    }
}
