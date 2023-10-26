using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TradingEvent", menuName = "SeniorProjectGame/Event/DecisionEvent/TradingEvent/Food", order = 2)]

public class TradingResourceManager : MonoBehaviour
{
    [SerializeField] private KitchenResourceManagerScript krms;
    [SerializeField] GarageResourceManagerScript grms;

    private TradingEvent tradingEvent;

    public static event Action OnTradeFinish , OnResourceLack;

    private void OnEnable() 
    {
        TradingEventManager.OnGenerateTradeDeal += TradeDeal;
    }
    private void OnDisable() 
    {
        TradingEventManager.OnGenerateTradeDeal -= TradeDeal;

    }
    public void TradeDeal(TradingEvent tradingEvent)
    {
        this.tradingEvent = tradingEvent;
        CheckResource();

    }

    private void CheckResource()
    {
        bool enoughResources = true; 

        foreach (TradingEvent.GameResources gameResources in tradingEvent.wantResources.resourceList)
        {
            switch (gameResources.resourcesName)
            {
                case "wood":
                    if (grms.WoodAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break; 
                    }
                    break;
                case "metal":
                    if (grms.MetalAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "tape":
                    if (grms.TapeAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "clothe":
                    if (grms.ClotheAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "guncomponent":
                    if (grms.GunComponentAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "gunpowder":
                    if (grms.GunPowderAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "herb":
                    if (grms.HerbAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;

                 case "meat" :
                    if (krms.RawMeatAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "canfood" :
                    if (krms.CanFoodAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "water" :
                    if (krms.WaterAmount< gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "cucumber" :
                    if (krms.CucumberAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "cabbage" :
                    if (krms.CabbageAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "tomato" :
                    if (krms.TomatoAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "potato" :
                    if (krms.PotatoAmount< gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
                case "carrot" :
                    if (krms.CarrotAmount < gameResources.resourcesAmount)
                    {
                        enoughResources = false;
                        break;
                    }
                    break;
            }
        }

        if (!enoughResources)
        {
            OnResourceLack?.Invoke();
        }
    }

    public void AcceptTrade()
    {
        Debug.Log(tradingEvent.eventName.ToString());
        Debug.Log($"resource list count : {tradingEvent.wantResources.resourceList.Count}");
        foreach(TradingEvent.GameResources gameResources in tradingEvent.wantResources.resourceList)
        {
            switch(gameResources.resourcesName)
            {
                case "wood":
                    grms.WoodAmount -= gameResources.resourcesAmount;
                    break;
                case "metal":
                    grms.MetalAmount -= gameResources.resourcesAmount;
                    break;
                case "tape":
                    grms.TapeAmount -= gameResources.resourcesAmount;
                    break;
                case "clothe":
                    grms.ClotheAmount -= gameResources.resourcesAmount;
                    break;
                case "guncomponent":
                    grms.GunComponentAmount -= gameResources.resourcesAmount;
                    break;
                case "gunpowder":
                    grms.GunPowderAmount -= gameResources.resourcesAmount;
                    break;
                case "herb":
                    grms.HerbAmount -= gameResources.resourcesAmount;
                    break;

                case "meat" :
                    krms.RawMeatAmount -= gameResources.resourcesAmount;
                    break;
                case "canfood" :
                    krms.CanFoodAmount -= gameResources.resourcesAmount;
                    break;
                case "water" :
                    krms.WaterAmount -= gameResources.resourcesAmount;
                    break;
                case "cucumber" :
                    krms.CucumberAmount -= gameResources.resourcesAmount;
                    break;
                case "cabbage" :
                    krms.CabbageAmount -= gameResources.resourcesAmount;
                    break;
                case "tomato" :
                    krms.TomatoAmount -= gameResources.resourcesAmount;
                    break;
                case "potato" :
                    krms.PotatoAmount -= gameResources.resourcesAmount;
                    break;
                case "carrot" :
                    krms.CarrotAmount -= gameResources.resourcesAmount;
                    break;
                
            }
        }
        foreach(TradingEvent.GameResources gameResources in tradingEvent.receiveResources.resourceList)
        {
            switch(gameResources.resourcesName)
            {
                case  "wood":
                    grms.WoodAmount += gameResources.resourcesAmount;
                    break;
                case "metal":
                    grms.MetalAmount += gameResources.resourcesAmount;
                    break;
                case "tape":
                    grms.TapeAmount += gameResources.resourcesAmount;
                    break;
                case "clothe":
                    grms.ClotheAmount += gameResources.resourcesAmount;
                    break;
                case "guncomponent":
                    grms.GunComponentAmount += gameResources.resourcesAmount;
                    break;
                case "gunpowder":
                    grms.GunPowderAmount += gameResources.resourcesAmount;
                    break;
                case "herb":
                    grms.HerbAmount += gameResources.resourcesAmount;
                    break;


                 case "meat" :
                    krms.RawMeatAmount += gameResources.resourcesAmount;
                    break;
                case "canfood" :
                    krms.CanFoodAmount += gameResources.resourcesAmount;
                    break;
                case "water" :
                    krms.WaterAmount += gameResources.resourcesAmount;
                    break;
                case "cucumber" :
                    krms.CucumberAmount += gameResources.resourcesAmount;
                    break;
                case "cabbage" :
                    krms.CabbageAmount += gameResources.resourcesAmount;
                    break;
                case "tomato" :
                    krms.TomatoAmount += gameResources.resourcesAmount;
                    break;
                case "potato" :
                    krms.PotatoAmount += gameResources.resourcesAmount;
                    break;
                case "carrot" :
                    krms.CarrotAmount += gameResources.resourcesAmount;
                    break;

                
            }
        }
        tradingEvent.SaveEvent();
        tradingEvent.RefreshEvent();
        tradingEvent.ResetList();
        tradingEvent.wantResources.ClearList();
        tradingEvent.receiveResources.ClearList();
        OnTradeFinish?.Invoke();
    }
    public void DeclineTrade()
    {
        OnTradeFinish?.Invoke();
    }
}
