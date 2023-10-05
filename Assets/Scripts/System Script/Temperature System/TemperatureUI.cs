using UnityEngine;
using TMPro;

public class TemperatureUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI temperatureText;
    TemperatureManager temperatureManager;
    public void Awake() 
    {
        temperatureManager = GetComponent<TemperatureManager>();
        temperatureManager.OnTemperatureChanged += SetTemperatureUI;
    }

    private void OnDisable() 
    {
        temperatureManager.OnTemperatureChanged -= SetTemperatureUI;
    }


    private void SetTemperatureUI(byte temperature)
    {
        temperatureText.text = $"Temperature : {temperature}";
    }

    
}
