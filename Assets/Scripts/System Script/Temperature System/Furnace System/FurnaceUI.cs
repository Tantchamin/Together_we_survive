using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FurnaceUI : BonfireUI
{
    [SerializeField] Furnace furnance;
    [SerializeField] private Slider fuelSlider;
    public Gradient fuelGradient;
    [SerializeField] private Image fill;
    [SerializeField] private TextMeshProUGUI furnaceStatus;
    private void OnEnable() {
        Furnace.OnValueChanged += OnSetFuel;
        Furnace.OnFurnaceSwitch += BonfireStatus;

        FurnaceFuel.OnFurnaceListShow += OnSetFuel;

        OnSetFuel();
    }

    private void OnDisable() {
        Furnace.OnValueChanged -= OnSetFuel;
        Furnace.OnFurnaceSwitch -= BonfireStatus;

        FurnaceFuel.OnFurnaceListShow -= OnSetFuel;
    }

    public void Start()
    {
        SetSlider();
    }

    protected override void SetSlider()
    {
        fuelSlider.maxValue = furnance.MaxFuel;
        fuelSlider.value = furnance.CurrentFuel;
        fill.color = fuelGradient.Evaluate(fuelSlider.normalizedValue);
        BonfireStatus(false);
    }

    public override void OnSetFuel()
    {
        fuelSlider.value = furnance.CurrentFuel;
        fill.color = fuelGradient.Evaluate(fuelSlider.normalizedValue);

    }

    protected override void BonfireStatus(bool _isLighted)
    {
        if(_isLighted == true)
        {
             furnaceStatus.text = "Ignited";
        }
        else
        furnaceStatus.text = "Exhausted";
    }
}