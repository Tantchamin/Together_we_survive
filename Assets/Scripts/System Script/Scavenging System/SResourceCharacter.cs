using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SResourceCharacter : MonoBehaviour
{
    private byte itemCarryAmount = 0;
    private byte characterStrength = 0;
    private byte toolItemSlot = 0;
    private void OnEnable() {
        CharacterNextButtonUI.OnScravengerInvoke += CharacterStrength;
        NightItemListManager.OnToolUse += SetCurrentTool;
    }

    private void OnDisable() {
        CharacterNextButtonUI.OnScravengerInvoke -= CharacterStrength;
        NightItemListManager.OnToolUse -= SetCurrentTool;
    }

    private void CharacterStrength(CharacterStat characterStat)
    {
        characterStrength = (byte)characterStat.StrengthCurrentValue;
    }



    public byte GetItemCarryAmount()
    {
        itemCarryAmount = 0;
        CalculateCarryAmount();
        Debug.Log($"Carry amount : {itemCarryAmount}");
        return itemCarryAmount;
    }

    private void CalculateCarryAmount()
    {
        itemCarryAmount += characterStrength;
        itemCarryAmount += toolItemSlot;
    }

    private void SetCurrentTool(Item item)
    {
        if(item == null)
        {
            toolItemSlot = 0;
        }
        else
        {   
            toolItemSlot = item.itemValue;
        }
        
    }
}
