using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnanceUI : MonoBehaviour
{
    Furnance furnance;
    [SerializeField] private Slider fuelSlider;
    public Gradient fuelGradient;
    [SerializeField] private Image fill;

    private void OnEnable() {
        Furnance.OnValueChanged += OnSetFuel;
        OnSetFuel();
    }

    private void OnDisable() {
        Furnance.OnValueChanged -= OnSetFuel;

    }

    public void Start()
    {
        furnance = FindObjectOfType<Furnance>();
        fuelSlider.maxValue = furnance.MaxFuel;
        fuelSlider.value = furnance.CurrentFuel;

        fill.color = fuelGradient.Evaluate(fuelSlider.normalizedValue);
    }

    public void OnSetFuel()
    {
        Debug.Log("On set fuel");
        fuelSlider.value = furnance.CurrentFuel;
        fill.color = fuelGradient.Evaluate(fuelSlider.normalizedValue);

    }
}
