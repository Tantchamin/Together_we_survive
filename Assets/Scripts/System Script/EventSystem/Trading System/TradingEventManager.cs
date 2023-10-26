using System;
using System.Collections.Generic;
using UnityEngine;

public class TradingEventManager : MonoBehaviour
{
    [SerializeField] private TradingEvent tradingEvent;
    private List<TradingEvent.GameResources> gameResourcesList = new List<TradingEvent.GameResources>();
    public static event Action<TradingEvent> OnGenerateTradeDeal;

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
        if(incomeTradeEvent is MaterialTradingEvent)
        {
            MaterialTradingEvent materialTradingEvent = incomeTradeEvent as MaterialTradingEvent;
            tradingEvent = materialTradingEvent;
            GenerateMaterialTradeList(materialTradingEvent);
        }
        else if(incomeTradeEvent is FoodTradingEvent)
        {
            FoodTradingEvent foodTradingEvent = incomeTradeEvent as FoodTradingEvent;
            tradingEvent = foodTradingEvent;
            GenerateFoodTradeList(foodTradingEvent);
        }
        

        // Debug.Log(tradingEvent.wantResources.clotheAmount);
        // Debug.Log(tradingEvent.wantResources.woodAmount);


        OnGenerateTradeDeal?.Invoke(tradingEvent);
    }

    private void GenerateMaterialTradeList(MaterialTradingEvent tradeEvent)
    {
        tradeEvent.ResetList();
        tradeEvent.RefreshEvent();
        tradeEvent.FillGameResourceList();
        gameResourcesList = tradeEvent.availableResourcesList;
        gameResourcesList = tradeEvent.wantResources.GenerateTradeList(gameResourcesList);
        gameResourcesList = tradeEvent.receiveResources.GenerateTradeList(gameResourcesList);
        tradeEvent.SaveEvent();
    }
    private void GenerateFoodTradeList(FoodTradingEvent tradeEvent)
    {
        tradeEvent.ResetList();
        tradeEvent.RefreshEvent();
        tradeEvent.FillGameResourceList();
        gameResourcesList = tradeEvent.availableResourcesList;
        gameResourcesList = tradeEvent.wantResources.GenerateTradeList(gameResourcesList);
        gameResourcesList = tradeEvent.receiveResources.GenerateTradeList(gameResourcesList);
        tradeEvent.SaveEvent();
    }
    public void Test(TradingEvent tradingEvent)
    {
        Debug.Log(tradingEvent.eventName.ToString());
        Debug.Log(tradingEvent.wantResources.resourceList.Count.ToString());
        Debug.Log(tradingEvent.receiveResources.resourceList.Count.ToString());
    }

   
    // ทำระบบเทรดให้แฟร์ขึ้น เก็บจำนวนไอเท็มที่เทรด ให้มีความบาลานซ์ทั้งสองฝั่ง 
    // อาจจะทำให้มีระบบเทรดไอเท็ม(?) 
    // เทรดทรัพยากรประเภทอื่น
}
