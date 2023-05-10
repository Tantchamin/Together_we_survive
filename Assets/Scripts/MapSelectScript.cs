using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectScript : MonoBehaviour
{
    [SerializeField] private Toggle _villageToggle;
    [SerializeField] private Toggle _marketToggle;
    [SerializeField] private Toggle _hospitalToggle;
    [SerializeField] private Toggle _gasStationToggle;
    [SerializeField] private GarageResourceBackendScript _garageResourceBackendScript;
    [SerializeField] private KitchenResourceBackendScript _kitchenResorceBackendScript;
    ChooseCharacterManagerScript _chooseCharacterManagerScript;

    private void Start()
    {
        _garageResourceBackendScript.GetComponent<GarageResourceBackendScript>();
        _kitchenResorceBackendScript.GetComponent<KitchenResourceBackendScript>();
        _chooseCharacterManagerScript = GameObject.FindGameObjectWithTag("ChooseCharacterManager").GetComponent<ChooseCharacterManagerScript>();
    }

    public void NextDayButtonClick()
    {
        if (_villageToggle.isOn == true)
        {
            _kitchenResorceBackendScript.ReceiveRawFood(5);
            gameObject.SetActive(false);
        }
        else if (_marketToggle.isOn == true)
        {
            gameObject.SetActive(false);
        }
        else if(_hospitalToggle.isOn == true)
        {
            gameObject.SetActive(false);
        }
        else if(_gasStationToggle.isOn == true)
        {
            gameObject.SetActive(false);
        }

    }
}
