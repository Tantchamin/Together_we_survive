using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontYardUIManagerScript : MonoBehaviour
{

    [SerializeField] private GameObject _frontYardUpgradeButton;
    [SerializeField] private FrontYardHouseUpgradeManager frontYardUpgradeHouseManagerScript;
    private byte houseLevel;
    void Start()
    {
        houseLevel = (byte )frontYardUpgradeHouseManagerScript.GetHouseLevel();
    }

    private void OnEnable()
    {
        SwitchRoomScript.OnEnterFrontYard += EnterFrontYard;
        SwitchRoomScript.OnLeave += LeaveFrontYard;
        frontYardUpgradeHouseManagerScript.OnHouseStartUpgrade += SetFrontYardUI;
        FrontYardHouseUpgradeManager.OnHouseFinishUpgrade += GetHouseLevel;
    }

    private void OnDisable()
    {
        SwitchRoomScript.OnEnterFrontYard -= EnterFrontYard;
        SwitchRoomScript.OnLeave -= LeaveFrontYard;
        frontYardUpgradeHouseManagerScript.OnHouseStartUpgrade -= SetFrontYardUI;
        FrontYardHouseUpgradeManager.OnHouseFinishUpgrade -= GetHouseLevel;

    }

    private void GetHouseLevel()
    {
        houseLevel = (byte) frontYardUpgradeHouseManagerScript.GetHouseLevel();
    }
    private void EnterFrontYard()
    {
        if (frontYardUpgradeHouseManagerScript.IsHouseUpgrading() == false || houseLevel < 3)
            {
                SetFrontYardUI(true);
            }    
    }
    private void LeaveFrontYard()
    {
        SetFrontYardUI(false);
    }
    private void SetFrontYardUI(bool isUIActive){
        _frontYardUpgradeButton.gameObject.SetActive(isUIActive);

    }
}
