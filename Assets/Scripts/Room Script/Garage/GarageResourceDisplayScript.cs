using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GarageResourceDisplayScript : MonoBehaviour
{

    [SerializeField] private Camera _roomCamera;
    [SerializeField] private GameObject _garageBG;
    [SerializeField] private GameObject _garageUI;
    [SerializeField] private TextMeshProUGUI _woodDisplayAmount;
    [SerializeField] private TextMeshProUGUI _metalDisplayAmount;
    [SerializeField] private TextMeshProUGUI _tapeDisplayAmount;
    [SerializeField] private TextMeshProUGUI _clotheDisplayAmount;
    [SerializeField] private TextMeshProUGUI _gunComponentDisplayAmount;
    [SerializeField] private TextMeshProUGUI _gunPowderDisplayAmount;
    [SerializeField] private TextMeshProUGUI _herbDisplayAmount;

    [SerializeField] private GameObject _craftUI;
    [SerializeField] private GameObject _inventoryUI;

    [SerializeField] private GameObject _craftUIฺButton;

    [SerializeField] private GameObject _inventoryUIButton;

    private bool isCameraHere = false;

    GarageResourceManagerScript garageResourceManagerScript;
    void Start()
    {
        _garageUI = GameObject.Find("GarageResourceUI");
        _craftUI = GameObject.Find("CraftedItemUI");
        _craftUIฺButton = GameObject.Find("CraftedItemButton");
        _inventoryUIButton = GameObject.Find("InventoryButton");
        _inventoryUI = GameObject.Find("InventoryUI");
        _craftUI.SetActive(false);
        _inventoryUI.SetActive(false);
        garageResourceManagerScript = GetComponent<GarageResourceManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayGarageResource();
        if(_roomCamera.transform.position.x == _garageBG.transform.position.x){    
            if(isCameraHere == false){
                isCameraHere = true;
                SetGarageUIActive(true);
            }
            else return;
            
        }
        else{
            SetGarageUIActive(false);
            isCameraHere = false;
        }
        
    }

    private void SetGarageUIActive(bool _isUIActive){
        _garageUI.SetActive(_isUIActive);
        _craftUIฺButton.SetActive(_isUIActive);
        _inventoryUIButton.SetActive(_isUIActive);
        
    }

    private void DisplayGarageResource(){
        _woodDisplayAmount.text =  garageResourceManagerScript.GetResourceFromList(0).ToString();
        _metalDisplayAmount.text = garageResourceManagerScript.GetResourceFromList(1).ToString();
        _tapeDisplayAmount.text =  garageResourceManagerScript.GetResourceFromList(2).ToString();
        _clotheDisplayAmount.text =  garageResourceManagerScript.GetResourceFromList(3).ToString();
        _gunComponentDisplayAmount.text =  garageResourceManagerScript.GetResourceFromList(4).ToString();
        _gunPowderDisplayAmount.text =  garageResourceManagerScript.GetResourceFromList(5).ToString();
        _herbDisplayAmount.text = garageResourceManagerScript.GetResourceFromList(6).ToString();

    }
}
