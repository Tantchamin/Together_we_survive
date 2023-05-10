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

    public void NextDayButtonClick()
    {
        if (_villageToggle.isOn == true)
        {

        }
        else if (_marketToggle.isOn == true)
        {

        }
        else if(_hospitalToggle.isOn == true)
        {

        }
        else if(_gasStationToggle.isOn == true)
        {

        }

    }
}
