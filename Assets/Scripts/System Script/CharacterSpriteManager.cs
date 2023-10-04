using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpriteManager : MonoBehaviour
{
    private CharacterStatManager characterStatManager;
    [SerializeField] private GameObject injuredSprite, tiredSprite, sickSprite,
     infectedSprite, hungrySprite, thirstySprite, deadSprite, characterSprite;

    private List<GameObject> spriteList = new List<GameObject>();
    public void Awake()
    {
        characterStatManager = GetComponent<CharacterStatManager>();

        TriggerEvent();
       
    }

    private void OnDisable()
    {
        UnTriggerEvent();
    }

    private void TriggerEvent()
    {
        characterStatManager.OnHungry += HungryState;
        characterStatManager.OnStopHungry += DeHungryState;

        characterStatManager.OnThirsty += ThirstyState;
        characterStatManager.OnStopThirsty += DeThirstyState;

        characterStatManager.OnTired += TiredState;
        characterStatManager.OnStopTired += DeTiredState;

        characterStatManager.OnWound += WoundState;
        characterStatManager.OnStopWound += DeWoundState;

        characterStatManager.OnSick += SickState;
        characterStatManager.OnStopSick += DeSickState;

        characterStatManager.OnInfected += InfectState;
        characterStatManager.OnStopInfected += DeInfectState;

        characterStatManager.OnDead += DeadState;
    }

    private void UnTriggerEvent()
    {
        characterStatManager.OnHungry -= HungryState;
        characterStatManager.OnStopHungry -= DeHungryState;

        characterStatManager.OnThirsty -= ThirstyState;
        characterStatManager.OnStopThirsty -= DeThirstyState;

        characterStatManager.OnTired -= TiredState;
        characterStatManager.OnStopTired -= DeTiredState;

        characterStatManager.OnWound -= WoundState;
        characterStatManager.OnStopWound -= DeWoundState;

        characterStatManager.OnSick -= SickState;
        characterStatManager.OnStopSick -= DeSickState;

        characterStatManager.OnInfected -= InfectState;
        characterStatManager.OnStopInfected -= DeInfectState;

        characterStatManager.OnDead -= DeadState;
    }
    public void Start()
    {
        spriteList.Add(injuredSprite);
        spriteList.Add(tiredSprite);
        spriteList.Add(sickSprite);
        spriteList.Add(infectedSprite);
        spriteList.Add(hungrySprite);
        spriteList.Add(thirstySprite);
        spriteList.Add(deadSprite);

        foreach (GameObject sprite in spriteList)
        {
            sprite.SetActive(false);
        }
    }
    // HUNGRY
    private void HungryState()
    {
        hungrySprite.SetActive(true);
    }
    private void DeHungryState()
    {
        if(hungrySprite.activeSelf == false) return;
        hungrySprite.SetActive(false);
    }
    // THIRSTY

    private void ThirstyState()
    {
        thirstySprite.SetActive(true);
    }
    private void DeThirstyState()
    {
        if(thirstySprite.activeSelf == false) return;
        thirstySprite.SetActive(false);
    }

    //WOUND

    private void WoundState()
    {
        injuredSprite.SetActive(true);
    }
    private void DeWoundState()
    {
        if(injuredSprite.activeSelf == false) return;
        injuredSprite.SetActive(false);
    }

    // TIRED

    private void TiredState()
    {
        tiredSprite.SetActive(true);
    }
    private void DeTiredState()
    {
        if(tiredSprite.activeSelf == false) return;
        tiredSprite.SetActive(false);
    }

    // SICK

    private void SickState()
    {
        sickSprite.SetActive(true);
    }
    private void DeSickState()
    {
        if(sickSprite.activeSelf == false) return;
        sickSprite.SetActive(false);
    }

    // INFECT

    private void InfectState()
    {
        infectedSprite.SetActive(true);
    }
    private void DeInfectState()
    {
        if(infectedSprite.activeSelf == false) return;
        infectedSprite.SetActive(false);
    }

    // DEAD
    private void DeadState()
    {
        foreach(GameObject sprite in spriteList)
        {
            sprite.SetActive(false);
        }
        deadSprite.SetActive(true);
        characterSprite.SetActive(false);
        this.enabled = false;
    }

}
