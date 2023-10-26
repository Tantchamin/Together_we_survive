using System.Reflection;
using UnityEngine;
[CreateAssetMenu(fileName = "FoodTradingEvent", menuName = "SeniorProjectGame/Event/DecisionEvent/TradingEvent/Food", order = 2)]

public class FoodTradingEvent : TradingEvent
{
    public GameResources Meat = new GameResources("meat", 0);
    public GameResources Canfood = new GameResources("canfood", 0);
    public GameResources Water = new GameResources("water", 0);
    public GameResources Cucumber = new GameResources("cucumber", 0);
    public GameResources Cabbage = new GameResources("cabbage", 0);
    public GameResources Tomato = new GameResources("tomato", 0);
    public GameResources Potato = new GameResources("potato", 0);
    public GameResources Carrot = new GameResources("carrot" , 0);

    public override void FillGameResourceList()
    {
        availableResourcesList.Add(Meat);
        availableResourcesList.Add(Canfood);
        availableResourcesList.Add(Water);
        availableResourcesList.Add(Cucumber);
        availableResourcesList.Add(Cabbage);
        availableResourcesList.Add(Tomato);
        availableResourcesList.Add(Carrot);
        availableResourcesList.Add(Potato);
    
    }

    [System.Serializable]
    public new class TradingEventData
    {
        [Header ("Want Resource")]

        [Space(6)]
        public byte wantResourceTypeAmount;
        [Space(6)]
        public byte wantMeatResource , wantCanfoodResource , wantWaterResource , wantCucumberResource
         , wantTomatoResource , wantCabbageResource , wantPotatoResource , wantCarrotResource;

        [Header ("Receive Resource")]
         
        [Space(6)]
        public byte receiveResourceTypeAmount;
        [Space(6)]
        public byte receiveMeatResource , receiveCanfoodResouce , receiveWaterResouce , receiveCucumberResouce
         , receiveTomatoResource , receiveCabbageResource , receivePotatoResource , receiveCarrotResource;

    }
    [SerializeField] private TradingEventData eventData;
    public override void SaveEvent()
    {
        eventData = new TradingEventData
        {

            // YOU GIVE THE RESOURCE SECTION
            
                //MAX VALUE OF EACH AMOUNT AND TYPE
            wantResourceTypeAmount = wantResources.resourceTypeAmount,
            
                //RESOURCE AMOUNT
            wantMeatResource = Meat.resourcesAmount ,
            wantCanfoodResource  = Canfood.resourcesAmount,
            wantWaterResource  = Water.resourcesAmount,
            wantCucumberResource = Cucumber.resourcesAmount,
            wantTomatoResource = Tomato.resourcesAmount,
            wantCabbageResource = Cabbage.resourcesAmount,
            wantPotatoResource = Potato.resourcesAmount,
            wantCarrotResource =Carrot.resourcesAmount ,

            // YOU RECEIVE THE RESOURCE SECTION

                //MAX VALUE OF EACH AMOUNT AND TYPE
           receiveResourceTypeAmount = receiveResources.resourceTypeAmount,

                //RESOURCE AMOUNT
            receiveMeatResource = Meat.resourcesAmount ,
            receiveWaterResouce  = Water.resourcesAmount,
            receiveCanfoodResouce  = Canfood.resourcesAmount,
            receiveCabbageResource = Cabbage.resourcesAmount,
            receiveCucumberResouce = Cucumber.resourcesAmount,
            receivePotatoResource = Potato.resourcesAmount,
            receiveCarrotResource = Carrot.resourcesAmount,
            receiveTomatoResource = Tomato.resourcesAmount
        };
    }

    public void LoadEvent(TradingEventData eventData)
    {
        // Load data into wantResources
        wantResources.resourceTypeAmount = eventData.wantResourceTypeAmount;
        Meat.resourcesAmount = eventData.wantMeatResource;
        Water.resourcesAmount = eventData.wantWaterResource;
        Canfood.resourcesAmount = eventData.wantCanfoodResource;
        Cabbage.resourcesAmount = eventData.wantCabbageResource;
        Cucumber.resourcesAmount = eventData.wantCucumberResource;
        Potato.resourcesAmount = eventData.wantPotatoResource;
        Carrot.resourcesAmount = eventData.wantCarrotResource;
        Tomato.resourcesAmount =eventData.wantTomatoResource;
        // Load data into receiveResources
        receiveResources.resourceTypeAmount = eventData.receiveResourceTypeAmount;

        Meat.resourcesAmount = eventData.receiveMeatResource;
        Water.resourcesAmount = eventData.receiveWaterResouce;
        Canfood.resourcesAmount = eventData.receiveCanfoodResouce;
        Cabbage.resourcesAmount = eventData.receiveCabbageResource;
        Cucumber.resourcesAmount = eventData.receiveCucumberResouce;
        Potato.resourcesAmount = eventData.receivePotatoResource;
        Carrot.resourcesAmount = eventData.receiveCarrotResource;
        Tomato.resourcesAmount =eventData.receiveTomatoResource;
    }

    public override void RefreshEvent()
    {

        FieldInfo[] fields = eventData.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);

        // Set the values of all fields to 0
        foreach (var field in fields)
        {
            if (field.FieldType == typeof(byte))
            {
                Debug.Log("Hello");
                field.SetValue(eventData, (byte)0);
            }
        }
    }
}
