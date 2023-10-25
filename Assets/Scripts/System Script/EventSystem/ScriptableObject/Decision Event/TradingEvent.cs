using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "TradingEvent", menuName = "SeniorProjectGame/Event/DecisionEvent/TradingEvent", order = 0)]
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
    [System.Serializable]
    public class TradeResource
    {
        public byte resourceTypeAmount;
        public byte minResourceAmount, maxResourceAmount;
        public List<GameResources> allResourceList, resourceList = new List<GameResources>();
        public GameResources Wood = new GameResources("wood", 0);
        public GameResources Metal = new GameResources("metal", 0);
        public GameResources Tape = new GameResources("tape", 0);
        public GameResources Clothe = new GameResources("clothe", 0);
        public GameResources Guncomponent = new GameResources("guncomponent", 0);
        public GameResources Gunpowder = new GameResources("gunpowder", 0);
        public GameResources Herb = new GameResources("herb", 0);
        public void TradeResourceList()
        {
            allResourceList = new List<GameResources>();
            resourceList = new List<GameResources>();
        }
        public void GenerateTradeList()
        {
            TradeResourceList();
            ClearList();
            FillGameResourceList();
            while (resourceList.Count < resourceTypeAmount)
            {
                byte randomIndex = (byte)Random.Range(0, allResourceList.Count);
                if (resourceList.Contains(allResourceList[randomIndex])) continue;
                resourceList.Add(allResourceList[randomIndex]);
            }

            GenerateTradeResource();
        }

        public void ClearList()
        {
            if(allResourceList == null || resourceList == null) return;
            allResourceList.Clear();
            resourceList.Clear();
        }

        public void FillGameResourceList()
        {
            allResourceList.Add(Wood);
            allResourceList.Add(Metal);
            allResourceList.Add(Tape);
            allResourceList.Add(Clothe);
            allResourceList.Add(Guncomponent);
            allResourceList.Add(Gunpowder);
            allResourceList.Add(Herb);
        }

        public void GenerateTradeResource()
        {
            foreach (var gameResources in resourceList)
            {
                gameResources.resourcesAmount = (byte)Random.Range(minResourceAmount, maxResourceAmount);
            }
        }
    }

    public TradeResource wantResources = new TradeResource();
    public TradeResource receiveResources = new TradeResource();

    // THIS DATA WILL SHOW ON INSPECTOR (AKA SCRIPTABLE OBJECT)

    [System.Serializable]
    public class TradingEventData
    {
        [Header ("Want Resource")]

        [Space(6)]
        public byte wantResourceTypeAmount;
        [Space(6)]
        public byte wantWoodResource , wantMetalResouce , wantClotheResouce , wantTapeResouce , wantGuncomponentResource , wantGunpowderResource , wantHerbResource;
        [Header ("Receive Resource")]
         
        [Space(6)]
        public byte receiveResourceTypeAmount;
        [Space(6)]
        public byte receiveWoodResource , receiveMetalResouce , receiveClotheResouce , receiveTapeResouce , receiveGuncomponentResource , receiveGunpowderResource , receiveHerbResource;

    }
    [SerializeField] private TradingEventData eventData;
    

    public void SaveEvent()
    {
        eventData = new TradingEventData
        {

            // YOU GIVE THE RESOURCE SECTION
            
                //MAX VALUE OF EACH AMOUNT AND TYPE
            wantResourceTypeAmount = wantResources.resourceTypeAmount,
            
                //RESOURCE AMOUNT
            wantWoodResource = wantResources.Wood.resourcesAmount ,
            wantMetalResouce  = wantResources.Metal.resourcesAmount,
            wantClotheResouce  = wantResources.Clothe.resourcesAmount,
            wantTapeResouce = wantResources.Tape.resourcesAmount,
            wantGuncomponentResource = wantResources.Guncomponent.resourcesAmount,
            wantGunpowderResource = wantResources.Gunpowder.resourcesAmount,
            wantHerbResource = wantResources.Herb.resourcesAmount,


            // YOU RECEIVE THE RESOURCE SECTION

                //MAX VALUE OF EACH AMOUNT AND TYPE
           receiveResourceTypeAmount = receiveResources.resourceTypeAmount,

                //RESOURCE AMOUNT
            receiveWoodResource = receiveResources.Wood.resourcesAmount ,
            receiveMetalResouce  = receiveResources.Metal.resourcesAmount,
            receiveClotheResouce  = receiveResources.Clothe.resourcesAmount,
            receiveTapeResouce = receiveResources.Tape.resourcesAmount,
            receiveGuncomponentResource = receiveResources.Guncomponent.resourcesAmount,
            receiveGunpowderResource = receiveResources.Gunpowder.resourcesAmount,
            receiveHerbResource = receiveResources.Herb.resourcesAmount,
        };
    }

    public void LoadEvent(TradingEventData eventData)
    {
        // Load data into wantResources
        wantResources.resourceTypeAmount = eventData.wantResourceTypeAmount;

        wantResources.Wood.resourcesAmount = eventData.wantWoodResource;
        wantResources.Metal.resourcesAmount = eventData.wantMetalResouce;
        wantResources.Clothe.resourcesAmount = eventData.wantClotheResouce;
        wantResources.Tape.resourcesAmount = eventData.wantTapeResouce;
        wantResources.Guncomponent.resourcesAmount = eventData.wantGuncomponentResource;
        wantResources.Gunpowder.resourcesAmount = eventData.wantGunpowderResource;
        wantResources.Herb.resourcesAmount = eventData.wantHerbResource;

        // Load data into receiveResources
        receiveResources.resourceTypeAmount = eventData.receiveResourceTypeAmount;

        receiveResources.Wood.resourcesAmount = eventData.receiveWoodResource;
        receiveResources.Metal.resourcesAmount = eventData.receiveMetalResouce;
        receiveResources.Clothe.resourcesAmount = eventData.receiveClotheResouce;
        receiveResources.Tape.resourcesAmount = eventData.receiveTapeResouce;
        receiveResources.Guncomponent.resourcesAmount = eventData.receiveGuncomponentResource;
        receiveResources.Gunpowder.resourcesAmount = eventData.receiveGunpowderResource;
        receiveResources.Herb.resourcesAmount = eventData.receiveHerbResource;
    }

    public void RefreshEvent()
    {
       // wantResources.resourceTypeAmount = 0;

        wantResources.Wood.resourcesAmount = 0;
        wantResources.Metal.resourcesAmount = 0;
        wantResources.Clothe.resourcesAmount = 0;
        wantResources.Tape.resourcesAmount = 0;
        wantResources.Guncomponent.resourcesAmount = 0;
        wantResources.Gunpowder.resourcesAmount = 0;
        wantResources.Herb.resourcesAmount = 0;

       // receiveResources.resourceTypeAmount = 0;

        receiveResources.Wood.resourcesAmount = 0;
        receiveResources.Metal.resourcesAmount = 0;
        receiveResources.Clothe.resourcesAmount = 0;
        receiveResources.Tape.resourcesAmount = 0;
        receiveResources.Guncomponent.resourcesAmount = 0;
        receiveResources.Gunpowder.resourcesAmount = 0;
        receiveResources.Herb.resourcesAmount = 0;
}
         

}
