using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureManagerScript : MonoBehaviour
{
    [SerializeField] private int _temperature = 28;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTemperature(int _setTemperature)
    {
        _temperature = _setTemperature;
    }

    public int GetTemperature()
    {
        return _temperature;
    }
}
