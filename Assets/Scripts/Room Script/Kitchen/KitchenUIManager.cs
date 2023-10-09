using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenUIManager : MonoBehaviour
{
    [SerializeField] private GameObject kitchenUI;
    private void Start() 
    {
        kitchenUI.SetActive(false);
    }

    private void OnEnable()
    {
        SwitchRoomScript.OnEnterKitchen += EnterKitchen;
        SwitchRoomScript.OnLeave += LeaveKitchen;
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
}
