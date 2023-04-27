using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GarageResourceFrontendScript : MonoBehaviour
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

    GarageResourceBackendScript garageResourceBackendScript;
    void Start()
    {
        _garageUI = GameObject.Find("GarageResourceUI");
        garageResourceBackendScript = GetComponent<GarageResourceBackendScript>();
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

    public void SetGarageUIActive(bool _uiActive){
        _garageUI.SetActive(_uiActive);
        DisplayGarageResource();
    }

    private void DisplayGarageResource(){
        _woodDisplayAmount.text =  garageResourceBackendScript.GetResourceFromList(0).ToString();
        _metalDisplayAmount.text = garageResourceBackendScript.GetResourceFromList(1).ToString();
        _tapeDisplayAmount.text =  garageResourceBackendScript.GetResourceFromList(2).ToString();
        _clotheDisplayAmount.text =  garageResourceBackendScript.GetResourceFromList(3).ToString();
        _gunComponentDisplayAmount.text =  garageResourceBackendScript.GetResourceFromList(4).ToString();
        _gunPowderDisplayAmount.text =  garageResourceBackendScript.GetResourceFromList(5).ToString();
        _herbDisplayAmount.text = garageResourceBackendScript.GetResourceFromList(6).ToString();

    }
}
