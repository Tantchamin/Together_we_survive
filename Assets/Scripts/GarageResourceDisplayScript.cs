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

    GarageResourceManagerScript garageResourceManagerScript;
    void Start()
    {
        _garageUI = GameObject.Find("GarageResourceUI");
        _craftUI = GameObject.Find("CraftedItemUI");
        _craftUI.SetActive(false);
        garageResourceManagerScript = GetComponent<GarageResourceManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_roomCamera.transform.position.x == _garageBG.transform.position.x){    
            SetGarageUIActive(true);
        }
        else{
            SetGarageUIActive(false);
        }
    }

    private void SetGarageUIActive(bool _isUIActive){
        _garageUI.SetActive(_isUIActive);
        DisplayGarageResource();
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
