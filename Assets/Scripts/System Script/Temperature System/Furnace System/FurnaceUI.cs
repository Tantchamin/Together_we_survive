using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FurnaceUI : MonoBehaviour
{
    [SerializeField] Furnace furnance;
    [SerializeField] private Slider fuelSlider;
    public Gradient fuelGradient;
    [SerializeField] private Image fill;
    [SerializeField] private TextMeshProUGUI furnaceStatus;
    private void OnEnable() {
        Furnace.OnValueChanged += OnSetFuel;
        Furnace.OnFurnaceSwitch += FurnaceStatus;

        FurnaceFuel.OnShowList += OnSetFuel;

        OnSetFuel();
    }

    private void OnDisable() {
        Furnace.OnValueChanged -= OnSetFuel;
        Furnace.OnFurnaceSwitch -= FurnaceStatus;

        FurnaceFuel.OnShowList -= OnSetFuel;
    }

    public void Start()
    {
        fuelSlider.maxValue = furnance.MaxFuel;
        fuelSlider.value = furnance.CurrentFuel;
        fill.color = fuelGradient.Evaluate(fuelSlider.normalizedValue);
        FurnaceStatus(false);
    }

    public void OnSetFuel()
    {
        Debug.Log("On set fuel");
        fuelSlider.value = furnance.CurrentFuel;
        fill.color = fuelGradient.Evaluate(fuelSlider.normalizedValue);

    }

    private void FurnaceStatus(bool _isLighted)
    {
        if(_isLighted == true)
        {
             furnaceStatus.text = "Ignited";
        }
        else
        furnaceStatus.text = "Exhausted";
    }
}
