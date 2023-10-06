using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NOT OPEN-CLOSED PRINCIPLE
public class FrontYardHouseUpgradeManager : MonoBehaviour
{   
    [SerializeField] private GarageResourceManagerScript garageResourceBackendScript;
    [SerializeField] private DayManagerScript DayManagerScript;

    private int woodAmount , metalAmount , tapeAmount; //necessary resource for upgrade
    private bool isUpgrading;
    private bool isUpgradable = false;

    private byte currentDays=1 , daysLeftToFinish , finishedDays;
    public HouseState houseState;
    [SerializeField] private HouseUpgradeMaterial houseLevel1;
    [SerializeField] private HouseUpgradeMaterial houseLevel2;
    [SerializeField] private HouseUpgradeMaterial houseLevel3;

    public event Action OnHouseFinishUpgrade;
    public event Action<bool>OnHouseStartUpgrade;

    public enum HouseState 
    {
        level0,
        level1,
        level2,
        level3
    }
    void Start()
    {
        houseState = HouseState.level0;
    }

    private void Awake() 
    {
        DayManagerScript = FindObjectOfType<DayManagerScript>();
    DayManagerScript.OnDayStart += UpdateDays;
        
    }

    private void OnDisable() 
    {
    DayManagerScript.OnDayStart -= UpdateDays;
    }

    private void UpdateResource()
    {
        woodAmount = garageResourceBackendScript.GetResourceFromList(0);
        metalAmount = garageResourceBackendScript.GetResourceFromList(1);
        tapeAmount = garageResourceBackendScript.GetResourceFromList(2);
    }

    public void UpgradeHouse(){
        isUpgradable = false;
        isUpgradable = UpgradeHouseCondition(houseState);
        if(isUpgradable == true) 
        {
            StartUpgrade();
            OnHouseStartUpgrade(false);    
        } 
    }

    public void StartUpgrade()
    {
        Debug.Log("Start upgrading");
        isUpgradable = false;
        isUpgrading = false;
        if(isUpgrading == false)
        {
            GetFinishDays();
        }
        isUpgrading = true;
        Upgrading();
    }

    private void UpdateDays()
    {
        currentDays = (byte) DayManagerScript.GetDays();
        Debug.Log($"Days is updating today is {currentDays} days");
        Upgrading();
    }   

    public void Upgrading()
    {
        if(currentDays == finishedDays)
        {
            FinishUpgrade();
        }
    }

    private byte GetFinishDays()
    {
        // Debug.Log("Get finish days");
        finishedDays = (houseState == HouseState.level0) ? (byte)(houseLevel1.UpgradeDays + currentDays) :
        (houseState == HouseState.level1) ? (byte)(houseLevel2.UpgradeDays + currentDays) :
        (houseState == HouseState.level2) ? (byte)(houseLevel3.UpgradeDays + currentDays) : (byte)0;

        return finishedDays;
    }

    public void FinishUpgrade()
    {
        isUpgrading = false;
        houseState += 1;
        Debug.Log(houseState);
        OnHouseFinishUpgrade?.Invoke();
        Debug.Log("Finish Upgrade");
    }

    private bool UpgradeHouseCondition(HouseState houseState){
        UpdateResource();

        return (houseState == HouseState.level0) ? HouseLevelOneCondition() : 
        (houseState == HouseState.level1) ? HouseLevelTwoCondition() :
        (houseState == HouseState.level2 ) ? HouseLevelThreeCondition() : false;

    }

    private bool HouseLevelOneCondition(){
        if(woodAmount < houseLevel1.WoodAmount) return false;
        if(metalAmount < houseLevel1.MetalAmount) return false;
        if(tapeAmount < houseLevel1.TapeAmount) return false;

        garageResourceBackendScript.UseResourceFromList(houseLevel1.WoodAmount,0);
        garageResourceBackendScript.UseResourceFromList(houseLevel1.MetalAmount,1);
        garageResourceBackendScript.UseResourceFromList(houseLevel1.TapeAmount,2);

        return true;
    }

    private bool HouseLevelTwoCondition(){
        Debug.Log("It's pass thourgh here");
        if(woodAmount < houseLevel2.WoodAmount) return false;
        if(metalAmount <houseLevel2.MetalAmount) return false;
        if(tapeAmount < houseLevel2.TapeAmount) return false;

        garageResourceBackendScript.UseResourceFromList(houseLevel2.WoodAmount,0);
        garageResourceBackendScript.UseResourceFromList(houseLevel2.MetalAmount,1);
        garageResourceBackendScript.UseResourceFromList(houseLevel2.TapeAmount,2);

        return true;
    }

    private bool HouseLevelThreeCondition(){
        if(woodAmount < houseLevel3.WoodAmount) return false;
        if(metalAmount <houseLevel3.MetalAmount) return false;
        if(tapeAmount < houseLevel3.TapeAmount) return false;

        garageResourceBackendScript.UseResourceFromList(houseLevel3.WoodAmount,0);
        garageResourceBackendScript.UseResourceFromList(houseLevel3.MetalAmount,1);
        garageResourceBackendScript.UseResourceFromList(houseLevel3.TapeAmount,2);

        return true;
    }

    public HouseState GetHouseLevel(){
        return houseState;
    }

    public bool IsHouseUpgrading()
    {
        return isUpgrading;
    }

}
