using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontYardUIManagerScript : MonoBehaviour
{
    [SerializeField] private Camera _roomCamera;

    [SerializeField] private GameObject _frontYardBG;

    [SerializeField] private GameObject _frontYardUpgradeButton;
    [SerializeField] private FrontYardUpgradeHouseManager frontYardUpgradeHouseManagerScript;
    private byte _houseLevel;



    void Start()
    {
        _houseLevel = frontYardUpgradeHouseManagerScript.GetHouseLevel();
        _roomCamera = Camera.main;
        _frontYardUpgradeButton = GameObject.Find("BuildResourceUI");
    }

    // Update is called once per frame
    void Update()
    {
        _houseLevel = frontYardUpgradeHouseManagerScript.GetHouseLevel();
        if(_roomCamera.transform.position.x == _frontYardBG.transform.position.x && _houseLevel <3){
                
            SetFrontYardUI(true);
        }
        else{
            SetFrontYardUI(false);
        }
    }

    private void SetFrontYardUI(bool _isUIActive){
        _frontYardUpgradeButton.gameObject.SetActive(_isUIActive);
    }
}
