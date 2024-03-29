using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GarageResourceDisplayScript : MonoBehaviour
{
    public static event Action<bool> OnGarageDisplay;

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
    private bool isCameraHere = false;

    GarageResourceManagerScript garageResourceManagerScript;

    private void OnEnable() {
        OnGarageDisplay += SetGarageUIActive;
    }
    private void OnDisable() {
        OnGarageDisplay -= SetGarageUIActive;
    }
    void Start()
    {
        _garageUI = GameObject.Find("GarageResourceUI");
        garageResourceManagerScript = GetComponent<GarageResourceManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayGarageResource();
        if(_roomCamera.transform.position.x == _garageBG.transform.position.x){    
            if(isCameraHere == false){
                isCameraHere = true;
                OnGarageDisplay?.Invoke(true);
            }
            else return;
            
        }
        else{
            OnGarageDisplay?.Invoke(false);
            isCameraHere = false;
        }
        
    }

    private void SetGarageUIActive(bool _isUIActive){
        _garageUI.SetActive(_isUIActive);
  
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
