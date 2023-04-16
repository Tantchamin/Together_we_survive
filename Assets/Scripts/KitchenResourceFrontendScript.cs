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
    [SerializeField] private TextMeshProUGUI _cannedFoodDisplayAmount;
    [SerializeField] private TextMeshProUGUI _medicineDisplayAmount;
    [SerializeField] private TextMeshProUGUI _waterDisplayAmount;
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
        DisplayResouce();
        
    }

    public void SetKitchenUIActive(bool _uiActive){
        _kitchenUI.SetActive(_uiActive);
    }

    private void DisplayResouce(){
        DisplayRawFoodAmount();
        DisplayCannedFoodAmount();
        DisplayMedicineAmount();
        DisplayWaterAmount();
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
}

