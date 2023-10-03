using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontYardUIManagerScript : MonoBehaviour
{
    [SerializeField] private Camera _roomCamera;

    [SerializeField] private GameObject _frontYardBG;

    [SerializeField] private GameObject _frontYardUpgradeButton;
    [SerializeField] private FrontYardHouseUpgradeManager frontYardUpgradeHouseManagerScript;
    private byte _houseLevel;
    void Start()
    {
        _houseLevel = (byte )frontYardUpgradeHouseManagerScript.GetHouseLevel();
        _roomCamera = Camera.main;
    }

    private void OnEnable()
    {
        frontYardUpgradeHouseManagerScript.OnHouseStartUpgrade += SetFrontYardUI;
    }

    private void OnDisable()
    {
        frontYardUpgradeHouseManagerScript.OnHouseStartUpgrade -= SetFrontYardUI;
    }

    void Update()
    {
        _houseLevel = (byte) frontYardUpgradeHouseManagerScript.GetHouseLevel();
        if(_roomCamera.transform.position.x == _frontYardBG.transform.position.x && _houseLevel <3){
            // Debug.Log(frontYardUpgradeHouseManagerScript.IsHouseUpgrading().ToString());
            if (frontYardUpgradeHouseManagerScript.IsHouseUpgrading() == false)
            {
                SetFrontYardUI(true);
            }    
        }
        else
        {
            SetFrontYardUI(false);
        }

        
    }

    private void SetFrontYardUI(bool isUIActive){
        _frontYardUpgradeButton.gameObject.SetActive(isUIActive);

    }
}
