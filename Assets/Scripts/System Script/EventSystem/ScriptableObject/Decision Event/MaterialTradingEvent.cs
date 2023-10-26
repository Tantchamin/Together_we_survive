using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialTradingEvent", menuName = "SeniorProjectGame/Event/DecisionEvent/TradingEvent/Material", order = 0)]
public class MaterialTradingEvent : TradingEvent
{
    public GameResources Wood = new GameResources("wood", 0);
    public GameResources Metal = new GameResources("metal", 0);
    public GameResources Tape = new GameResources("tape", 0);
    public GameResources Clothe = new GameResources("clothe", 0);
    public GameResources Guncomponent = new GameResources("guncomponent", 0);
    public GameResources Gunpowder = new GameResources("gunpowder", 0);
    public GameResources Herb = new GameResources("herb", 0);

    public override void FillGameResourceList()
    {
        availableResourcesList.Add(Wood);
        availableResourcesList.Add(Metal);
        availableResourcesList.Add(Tape);
        availableResourcesList.Add(Clothe);
        availableResourcesList.Add(Guncomponent);
        availableResourcesList.Add(Gunpowder);
        availableResourcesList.Add(Herb);
    
    }

    [System.Serializable]
    public new class TradingEventData
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
    public override void SaveEvent()
    {
        eventData = new TradingEventData
        {

            // YOU GIVE THE RESOURCE SECTION
            
                //MAX VALUE OF EACH AMOUNT AND TYPE
            wantResourceTypeAmount = wantResources.resourceTypeAmount,
            
                //RESOURCE AMOUNT
            wantWoodResource = Wood.resourcesAmount ,
            wantMetalResouce  = Metal.resourcesAmount,
            wantClotheResouce  = Clothe.resourcesAmount,
            wantTapeResouce = Tape.resourcesAmount,
            wantGuncomponentResource = Guncomponent.resourcesAmount,
            wantGunpowderResource = Gunpowder.resourcesAmount,
            wantHerbResource = Herb.resourcesAmount,


            // YOU RECEIVE THE RESOURCE SECTION

                //MAX VALUE OF EACH AMOUNT AND TYPE
           receiveResourceTypeAmount = receiveResources.resourceTypeAmount,

                //RESOURCE AMOUNT
            receiveWoodResource = Wood.resourcesAmount ,
            receiveMetalResouce  = Metal.resourcesAmount,
            receiveClotheResouce  = Clothe.resourcesAmount,
            receiveTapeResouce = Tape.resourcesAmount,
            receiveGuncomponentResource = Guncomponent.resourcesAmount,
            receiveGunpowderResource = Gunpowder.resourcesAmount,
            receiveHerbResource = Herb.resourcesAmount,
        };
    }

    public void LoadEvent(TradingEventData eventData)
    {
        // Load data into wantResources
        wantResources.resourceTypeAmount = eventData.wantResourceTypeAmount;

        // wantResources.Wood.resourcesAmount = eventData.wantWoodResource;
        // wantResources.Metal.resourcesAmount = eventData.wantMetalResouce;
        // wantResources.Clothe.resourcesAmount = eventData.wantClotheResouce;
        // wantResources.Tape.resourcesAmount = eventData.wantTapeResouce;
        // wantResources.Guncomponent.resourcesAmount = eventData.wantGuncomponentResource;
        // wantResources.Gunpowder.resourcesAmount = eventData.wantGunpowderResource;
        // wantResources.Herb.resourcesAmount = eventData.wantHerbResource;

        // Load data into receiveResources
        receiveResources.resourceTypeAmount = eventData.receiveResourceTypeAmount;

        Wood.resourcesAmount = eventData.receiveWoodResource;
        Metal.resourcesAmount = eventData.receiveMetalResouce;
        Clothe.resourcesAmount = eventData.receiveClotheResouce;
        Tape.resourcesAmount = eventData.receiveTapeResouce;
        Guncomponent.resourcesAmount = eventData.receiveGuncomponentResource;
        Gunpowder.resourcesAmount = eventData.receiveGunpowderResource;
        Herb.resourcesAmount = eventData.receiveHerbResource;
    }

    public override void RefreshEvent()
    {
       //wantResources.resourceTypeAmount = 0;

    //     Wood.resourcesAmount = 0;
    //     Metal.resourcesAmount = 0;
    //     Clothe.resourcesAmount = 0;
    //     Tape.resourcesAmount = 0;
    //     Guncomponent.resourcesAmount = 0;
    //     Gunpowder.resourcesAmount = 0;
    //     Herb.resourcesAmount = 0;

        //receiveResources.resourceTypeAmount = 0;

    //     eventData.receiveClotheResouce = 0;
        // receiveResources.Metal.resourcesAmount = 0;
        // receiveResources.Clothe.resourcesAmount = 0;
        // receiveResources.Tape.resourcesAmount = 0;
        // receiveResources.Guncomponent.resourcesAmount = 0;
        // receiveResources.Gunpowder.resourcesAmount = 0;
        // receiveResources.Herb.resourcesAmount = 0;

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
