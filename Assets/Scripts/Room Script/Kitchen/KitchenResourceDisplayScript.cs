using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KitchenResourceDisplayScript : MonoBehaviour
{
    [SerializeField] private Camera roomCamera;
    [SerializeField] private GameObject kitchenBG;
    [SerializeField] private GameObject kitchenUI;
    [SerializeField] private TextMeshProUGUI rawFoodDisplayAmount, vegetableFoodDisplayAmount, cannedFoodDisplayAmount, medicineDisplayAmount
    , waterDisplayAmount, bandageDisplayAmount , tomatoDisplayAmount , potatoDisplayAmount , cabbageDisplayAmount
    , cucumberDisplayAmount , carrotDisplayAmount ;
    KitchenResourceManagerScript kitchenResourceManagerScript;

    private void Awake() 
    {
        kitchenResourceManagerScript = GetComponent<KitchenResourceManagerScript>();
    }
    private void OnEnable() {
        kitchenResourceManagerScript.OnValueChanged += UpdateResourceValue;
        SwitchRoomScript.OnEnterKitchen += EnterKitchen;
        SwitchRoomScript.OnLeave += LeaveKitchen;
    }

    private void OnDisable() {
        kitchenResourceManagerScript.OnValueChanged -= UpdateResourceValue;
    }

    private void Start() {
        kitchenUI.SetActive(false);
    }

    private void EnterKitchen()
    {
         SetKitchenUIActive(true);
    }

    private void LeaveKitchen()
    {
        SetKitchenUIActive(false);
    }

    public void SetKitchenUIActive(bool _uiActive){
        kitchenUI.SetActive(_uiActive);
    }
    private void UpdateResourceValue()
    {
        rawFoodDisplayAmount.text = kitchenResourceManagerScript.RawFoodAmount.ToString();
        vegetableFoodDisplayAmount.text = kitchenResourceManagerScript.RawVegetableAmount.ToString();
        cannedFoodDisplayAmount.text = kitchenResourceManagerScript.CanFoodAmount.ToString();
        medicineDisplayAmount.text = kitchenResourceManagerScript.MedicineAmount.ToString();
        waterDisplayAmount.text = kitchenResourceManagerScript.WaterAmount.ToString();
        bandageDisplayAmount.text = kitchenResourceManagerScript.BandageAmount.ToString();
        tomatoDisplayAmount.text = kitchenResourceManagerScript.TomatoAmount.ToString();
        carrotDisplayAmount.text = kitchenResourceManagerScript.CarrotAmount.ToString();
        potatoDisplayAmount.text = kitchenResourceManagerScript.PotatoAmount.ToString();
        cabbageDisplayAmount.text = kitchenResourceManagerScript.CabbageAmount.ToString();
        cucumberDisplayAmount.text = kitchenResourceManagerScript.CucumberAmount.ToString();

    }
}

