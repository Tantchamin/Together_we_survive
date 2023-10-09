using UnityEngine;
using TMPro;

public class TemperatureUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI temperatureText;
    TemperatureManager temperatureManager;
    public void Awake() 
    {
        temperatureManager = GetComponent<TemperatureManager>();
    }

    private void OnEnable() {
        temperatureManager.OnTemperatureChanged += SetTemperatureUI;
    }

    private void OnDisable() 
    {
        temperatureManager.OnTemperatureChanged -= SetTemperatureUI;
    }


    private void SetTemperatureUI(float temperature)
    {
        temperatureText.text = $"Temperature :  {temperature:0.00}";
    }

    
}
