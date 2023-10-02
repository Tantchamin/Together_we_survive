using System;
using UnityEngine;
using TMPro;


public class GarageUIManager : MonoBehaviour
{

    [SerializeField] private GameObject _craftUI;
    [SerializeField] private GameObject _inventoryUI;

    [SerializeField] private GameObject _craftUIฺButton;

    [SerializeField] private GameObject _inventoryUIButton;


    private void OnEnable() {
        GarageResourceDisplayScript.OnGarageDisplay += SetGarageUIActive;
    }

    private void OnDisable(){
        GarageResourceDisplayScript.OnGarageDisplay -= SetGarageUIActive;
    }
   
    void Start()
    {
        _craftUI = GameObject.Find("CraftedItemUI");
        _craftUIฺButton = GameObject.Find("CraftedItemButton");
        _inventoryUIButton = GameObject.Find("InventoryButton");
        _inventoryUI = GameObject.Find("InventoryUI");
        _craftUI.SetActive(false);
        _inventoryUI.SetActive(false);
    }


    private void SetGarageUIActive(bool _isUIActive){ 
        _craftUIฺButton.SetActive(_isUIActive);
        _inventoryUIButton.SetActive(_isUIActive);
  
    }
        
}
