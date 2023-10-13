using System;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectScript : MonoBehaviour
{
    [SerializeField] private Toggle villageToggle;
    [SerializeField] private Toggle marketToggle;
    [SerializeField] private Toggle hospitalToggle;
    [SerializeField] private Toggle gasStationToggle;

    public static event Action OnVillageToggle , OnMarketToggle , OnHospitalToggle ,OnGasStationToggle;
   
    public void NextDayButtonClick()
    {
        VillageTooggle();
        HospitalToggle();
        MarketToggle();
        GasStationToogle();

        DayManagerScript.IncreaseDays();

    }

     public void VillageTooggle()
    {
        if(villageToggle.isOn == true)
        {
            OnVillageToggle?.Invoke();
        }
    }
    public void HospitalToggle()
    {
        if(hospitalToggle.isOn == true)
        {
            OnHospitalToggle?.Invoke();
        }
    }
    public void MarketToggle()
    {
        if(marketToggle.isOn == true)
        {
            OnMarketToggle?.Invoke();
        }
    }
    public void GasStationToogle()
    {
        if(gasStationToggle.isOn == true)
        {
            OnGasStationToggle?.Invoke();
        }
    }

}
