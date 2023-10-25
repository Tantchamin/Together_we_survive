using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomEventChance : MonoBehaviour
{
    [SerializeField] List<RandomEvent> randomEvents = new List<RandomEvent>();
    private byte days = 0 , eventDays , breakDays = 1;

    public static event Action<RandomEvent> OnPassiveEvent , OnDecisionEvent , OnTradingEvent;
    private void OnEnable() 
    {
        DayManagerScript.OnDayStart += EventChance;
    }
    private void OnDisable() {
        DayManagerScript.OnDayStart -= EventChance;
    }

    public void EventChance() // init function
    {
        GetCurrentDays();
        if(randomEvents.Any() == false) return;
        if(days - eventDays <= breakDays) return;
        Debug.Log("Hello here");
        RandomChance();
    }

    private void GetCurrentDays()
    {
        days = (byte)DayManagerScript.GetDays();
    }

    private void RandomChance()
    {
        byte randomNumber = (byte) UnityEngine.Random.Range(0,2);
        if(randomNumber == 1)
        {
            
            OEventSystem(RandomEvent());
        }
        Debug.Log($"Random number {randomNumber}");
    }

    private RandomEvent RandomEvent()
    {
        byte randomNum = (byte)UnityEngine.Random.Range(0 , randomEvents.Count);
        return randomEvents[randomNum];
    }

    private void OEventSystem(RandomEvent randomEvent)
    {
        Debug.Log(randomEvent.eventName.ToString());

        if(randomEvent is PassiveEvent)
        {
            Debug.Log("passive event!");
        }
        if(randomEvent is DecisionEvent)
        {
            Debug.Log("Decision event!");
            if(randomEvent is TradingEvent)
            {
                TradingEvent tradingEvent = randomEvent as TradingEvent;
                
                byte resourceTypeAmount = tradingEvent.GenerateResourceType();
                tradingEvent.RefreshEvent();
                tradingEvent.wantResources.GenerateTradeList();
                tradingEvent.receiveResources.GenerateTradeList();
                tradingEvent.SaveEvent();
                // Debug.Log(tradingEvent.wantResources.clotheAmount);
                // Debug.Log(tradingEvent.wantResources.woodAmount);

            }
        }
        eventDays = days;
    }

}
