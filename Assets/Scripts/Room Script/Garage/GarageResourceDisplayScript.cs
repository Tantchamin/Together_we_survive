using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GarageResourceDisplayScript : MonoBehaviour
{
    [SerializeField] private GameObject garageUI;
    [SerializeField] private TextMeshProUGUI woodDisplayAmount, metalDisplayAmount, tapeDisplayAmount, clotheDisplayAmount,
     gunComponentDisplayAmount, gunPowderDisplayAmount, herbDisplayAmount;

    GarageResourceManagerScript garageResourceManagerScript;

    private void OnEnable() {
        SwitchRoomScript.OnEnterGarage += EnterGarage;
        SwitchRoomScript.OnLeave += LevaeGarage;
        GarageResourceManagerScript.OnValueChanged += UpdateResourceValue;
    }
    private void OnDisable() {
        SwitchRoomScript.OnEnterGarage -= EnterGarage;
        SwitchRoomScript.OnLeave -= LevaeGarage;
    }
    void Start()
    {
        garageUI.SetActive(false);
        garageResourceManagerScript = GetComponent<GarageResourceManagerScript>();
    }

    private void EnterGarage()
    {
        SetGarageUIActive(true);
    }
    private void LevaeGarage()
    {
        SetGarageUIActive(false);
    }

    private void SetGarageUIActive(bool _isUIActive){
        garageUI.SetActive(_isUIActive);
  
    }

    

    private void UpdateResourceValue(){
        woodDisplayAmount.text =  garageResourceManagerScript.WoodAmount.ToString();
        metalDisplayAmount.text = garageResourceManagerScript.MetalAmount.ToString();
        tapeDisplayAmount.text =  garageResourceManagerScript.TapeAmount.ToString();
        clotheDisplayAmount.text =  garageResourceManagerScript.ClotheAmount.ToString();
        gunComponentDisplayAmount.text =  garageResourceManagerScript.GunComponentAmount.ToString();
        gunPowderDisplayAmount.text =  garageResourceManagerScript.GunPowderAmount.ToString();
        herbDisplayAmount.text = garageResourceManagerScript.HerbAmount.ToString();

    }
}
