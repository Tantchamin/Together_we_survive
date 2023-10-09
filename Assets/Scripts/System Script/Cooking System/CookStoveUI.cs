using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookStoveUI : BonfireUI
{
    [SerializeField] CookStove cookStove;
    [SerializeField] private Slider fuelSlider;
    public Gradient fuelGradient;
    [SerializeField] private Image fill;
    [SerializeField] private TextMeshProUGUI cookStoveStatus;
    private void OnEnable() {
        CookStove.OnValueChanged += OnSetFuel;
        CookStove.OnLightedSwitch += BonfireStatus;

        CookStoveFuel.OnStoveListShow += OnSetFuel;

        OnSetFuel();
    }

    private void OnDisable() {
        CookStove.OnValueChanged -= OnSetFuel;
        CookStove.OnLightedSwitch -= BonfireStatus;

        CookStoveFuel.OnStoveListShow -= OnSetFuel;
    }

    public void Start()
    {
        SetSlider();
    }

    protected override void SetSlider()
    {
        fuelSlider.maxValue = cookStove.MaxFuel;
        fuelSlider.value = cookStove.CurrentFuel;
        fill.color = fuelGradient.Evaluate(fuelSlider.normalizedValue);
        BonfireStatus(false);
    }

    public override void OnSetFuel()
    {
        fuelSlider.value = cookStove.CurrentFuel;
        fill.color = fuelGradient.Evaluate(fuelSlider.normalizedValue);

    }

    protected override void BonfireStatus(bool _isLighted)
    {
        if(_isLighted == true)
        {
             cookStoveStatus.text = "Ignited";
        }
        else
        cookStoveStatus.text = "Exhausted";
    }
}
