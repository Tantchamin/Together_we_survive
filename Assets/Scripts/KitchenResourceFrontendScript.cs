using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KitchenResourceFrontendScript : MonoBehaviour
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
    KitchenResourceBackendScript kitchenResourceBackendScript;


    void Start()
    {
        _kitchenUI = GameObject.Find("KitchenResourceUI");
        kitchenResourceBackendScript = GetComponent<KitchenResourceBackendScript>();
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
        _rawFoodDisplayAmount.text = kitchenResourceBackendScript.GetRawFoodAmount().ToString();
    }

    private void DisplayCannedFoodAmount(){
        _cannedFoodDisplayAmount.text = kitchenResourceBackendScript.GetCannedFoodAmount().ToString();
    }

    private void DisplayMedicineAmount(){
        _medicineDisplayAmount.text = kitchenResourceBackendScript.GetMedicineAmount().ToString();
    }

    private void DisplayWaterAmount(){
        _waterDisplayAmount.text = kitchenResourceBackendScript.GetWaterAmount().ToString();
    }

    private void DisplayVegetableFoddAmount()
    {
        _vegetableFoodDisplayAmount.text = kitchenResourceBackendScript.GetVegetableAmount().ToString();
    }

    private void DisplayBandageAmount()
    {
        _bandageDisplayAmount.text = kitchenResourceBackendScript.GetBandageAmount().ToString();
    }

}

