using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

public class TradingEvent : DecisionEvent
{
    private void Awake() 
    {
        RefreshEvent();
    }
    private byte resourcesTypeAmount, minResourceType, maxResourceType;
    public byte GenerateResourceType()
    {
        return resourcesTypeAmount = (byte) Random.Range(minResourceType , maxResourceType);
    }
    public class GameResources
    {
        public string resourcesName;
        public byte resourcesAmount;

        public GameResources(string resourcesName, byte resourcesAmount)
        {
            this.resourcesName = resourcesName;
            this.resourcesAmount = resourcesAmount;
        }
    }
    public List<GameResources> availableResourcesList = new List<GameResources>();
    public virtual void ResetList()
    {
        availableResourcesList.Clear();

    }
    public virtual void FillGameResourceList()
    {
        
    }
    [System.Serializable]
    public class TradeResource
    {
        public byte tradeValue;
        public byte minTradeValue , maxTradeValue;
        public byte resourceTypeAmount;
        public byte minResourceTypeAmount , maxResourceTypeAmount;
        public byte minResourceAmount, maxResourceAmount;
   
        public List<GameResources> allResourceList, resourceList = new List<GameResources>();

        public void TradeResourceList()
        {
            allResourceList = new List<GameResources>();
            resourceList = new List<GameResources>();
        }
        public void FillResourceList(List<GameResources> gameResourcesList)
        {
            allResourceList.AddRange(gameResourcesList);
        }
        public List<GameResources> GenerateTradeList(List<GameResources> gameResourcesList)
        {
            TradeResourceList();
            FillResourceList(gameResourcesList);
            resourceTypeAmount = (byte) Random.Range(minResourceTypeAmount, maxResourceTypeAmount);
            while (resourceList.Count < resourceTypeAmount)
            {
                byte randomIndex = (byte)Random.Range(0, allResourceList.Count);
                if (resourceList.Contains(allResourceList[randomIndex])) continue;
                resourceList.Add(allResourceList[randomIndex]);
                allResourceList.Remove(allResourceList[randomIndex]);
                
            }

            GenerateTradeResource();
            return allResourceList;
        }

        public void GenerateTradeResource()
        {
            byte currentTradeValue = 0;
            byte maxPossibleResourceAmount;
            tradeValue = (byte)Random.Range(minTradeValue , maxTradeValue);
            foreach (var gameResources in resourceList)
            {
                maxPossibleResourceAmount =(byte) Math.Min(maxResourceAmount, tradeValue-currentTradeValue);
                gameResources.resourcesAmount = (byte)Random.Range(minResourceAmount, maxPossibleResourceAmount);

                currentTradeValue += gameResources.resourcesAmount;
            }
        }
        
        public void ClearList()
        {
            if(allResourceList == null || resourceList == null) return;
            allResourceList.Clear();
            resourceList.Clear();
        }
    }

    

    public TradeResource wantResources = new TradeResource();
    public TradeResource receiveResources = new TradeResource();

    // THIS DATA WILL SHOW ON INSPECTOR (AKA SCRIPTABLE OBJECT)

    [System.Serializable]
    public class TradingEventData
    {

    }

    public virtual void SaveEvent()
    {
    }

    public virtual void LoadEvent(TradingEventData eventData)
    {
    }

    public virtual void RefreshEvent()
    {
    }
         

}
