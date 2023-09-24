using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KitchenResourceDisplayScript : MonoBehaviour
{
    [SerializeField] private Camera _roomCamera;
    [SerializeField] private GameObject _kitchenBG;
    [SerializeField] private GameObject _kitchenUI;
    [SerializeField] private TextMeshProUGUI _rawFoodDisplayAmount;
    [SerializeField] private TextMeshProUGUI _vegetableFoodDisplayAmount;
    [SerializeField] private TextMeshProUGUI _cannedFoodDisplayAmount;
    [SerializeField] private TextMeshProUGUI _medicineDisplayAmount;
    [SerializeField] private TextMeshProUGUI _waterDisplayAmount;
    [SerializeField] private TextMeshProUGUI _bandageDisplayAmount;
    KitchenResourceManagerScript kitchenResourceManagerScript;


    void Start()
    {
        _kitchenUI = GameObject.Find("KitchenResourceUI");
        kitchenResourceManagerScript = GetComponent<KitchenResourceManagerScript>();
    }


    private void Update()
    {
        if(_roomCamera.transform.position.x == _kitchenBG.transform.position.x){    
            SetKitchenUIActive(true);
        }
        else{
            SetKitchenUIActive(false);
        }
        DisplayKitchenResource();
        
    }

    public void SetKitchenUIActive(bool _uiActive){
        _kitchenUI.SetActive(_uiActive);
    }

    private void DisplayKitchenResource(){
        DisplayRawFoodAmount();
        DisplayCannedFoodAmount();
        DisplayMedicineAmount();
        DisplayWaterAmount();
        DisplayVegetableFoddAmount();
        DisplayBandageAmount();
        
    }

    private void DisplayRawFoodAmount(){
        _rawFoodDisplayAmount.text = kitchenResourceManagerScript.GetRawFoodAmount().ToString();
    }

    private void DisplayCannedFoodAmount(){
        _cannedFoodDisplayAmount.text = kitchenResourceManagerScript.GetCannedFoodAmount().ToString();
    }

    private void DisplayMedicineAmount(){
        _medicineDisplayAmount.text = kitchenResourceManagerScript.GetMedicineAmount().ToString();
    }

    private void DisplayWaterAmount(){
        _waterDisplayAmount.text = kitchenResourceManagerScript.GetWaterAmount().ToString();
    }

    private void DisplayVegetableFoddAmount()
    {
        _vegetableFoodDisplayAmount.text = kitchenResourceManagerScript.GetVegetableAmount().ToString();
    }

    private void DisplayBandageAmount()
    {
        _bandageDisplayAmount.text = kitchenResourceManagerScript.GetBandageAmount().ToString();
    }

}

