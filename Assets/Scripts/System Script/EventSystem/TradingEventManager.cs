using System;
using System.Collections.Generic;
using UnityEngine;

public class TradingEventManager : MonoBehaviour
{
    [SerializeField] private TradingEvent tradingEvent;
    [SerializeField] private KitchenResourceManagerScript krms;
    [SerializeField] GarageResourceManagerScript grms;

    public static event Action OnTradeFinish;
    private void OnEnable() 
    {
        RandomEventChance.OnTradingEvent += OnTraderArrive;
    }
    private void OnDisable() 
    {
        RandomEventChance.OnTradingEvent -= OnTraderArrive;
    }
    public void OnTraderArrive(RandomEvent randomEvent)
    {
        TradingEvent incomeTradeEvent = randomEvent as TradingEvent;
        tradingEvent = incomeTradeEvent;
        incomeTradeEvent.RefreshEvent();
        incomeTradeEvent.wantResources.GenerateTradeList();
        incomeTradeEvent.receiveResources.GenerateTradeList();
        incomeTradeEvent.SaveEvent();
        // Debug.Log(tradingEvent.wantResources.clotheAmount);
        // Debug.Log(tradingEvent.wantResources.woodAmount);
        Test(tradingEvent);
    }
    public void Test(TradingEvent tradingEvent)
    {
        Debug.Log(tradingEvent.eventName.ToString());
        Debug.Log(tradingEvent.wantResources.resourceList.Count.ToString());
        Debug.Log(tradingEvent.receiveResources.resourceList.Count.ToString());
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

                
            }
        }

        OnTradeFinish?.Invoke();
    }
    public void DeclineTrade()
    {
        OnTradeFinish?.Invoke();
    }

}
