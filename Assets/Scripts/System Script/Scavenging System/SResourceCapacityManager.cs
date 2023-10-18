using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SResourceCapacityManager : MonoBehaviour
{
    private Item selectedTool;
    private byte itemCarryAmount;
    private byte characterStrength = 0;
    private byte itemCapacitySlot = 0;
    private void OnEnable() {
        CharacterNextButtonUI.OnScavengerInvoke += CharacterStrength;
        NightItemListManager.OnToolUse += SetCurrentTool;
    }

    private void OnDisable() {
        CharacterNextButtonUI.OnScavengerInvoke -= CharacterStrength;
        NightItemListManager.OnToolUse -= SetCurrentTool;
    }

    private void CharacterStrength(CharacterStat characterStat)
    {
        characterStrength = (byte)characterStat.StrengthCurrentValue;
    }

    private void SetCurrentTool(Item item)
    {
        if(item == null)
        {
            itemCapacitySlot = 0;
        }
        else
        {   
            selectedTool = item;
            itemCapacitySlot = item.itemValue;
        }
        
    }

    public byte GetItemCarryAmount()
    {
        itemCarryAmount = 0; // reset it daily
        CalculateCarryAmount();
        Debug.Log($"Carry amount : {itemCarryAmount}");
        return itemCarryAmount;
    }

    private void CalculateCarryAmount()
    {
        CalculateCharacterStrength();
        CalculateCarriedItem();
    }

    private void CalculateCharacterStrength()
    {
        itemCarryAmount += characterStrength;
    }
    
    private void CalculateCarriedItem()
    {
        Tool tool = selectedTool as Tool;
        if(characterStrength <= tool.strengthRequired)
        {
            itemCapacitySlot /= 2;
        }
    }


}
