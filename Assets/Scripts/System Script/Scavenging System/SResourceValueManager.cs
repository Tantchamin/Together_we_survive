using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using System.Reflection;

public class SResourceValueManager : MonoBehaviour
{
    private byte resourceValueCounter , resourceAmountCounter , itemValueCounter , itemAmountCounter;    

    public static event Action<byte> OnResourceAmount , OnItemValue;
    private void OnEnable()
    {
        MapResource.OnResourceReport += ResourceReport;
    }
    private void OnDisable() 
    {
        MapResource.OnResourceReport -= ResourceReport;
    }
    private void ResourceReport(List<ResourceData> resourceListData , Dictionary<Item , byte> scavengeItemDic)
    {
        ResetResource();
        ResourceValue(resourceListData);
        ItemValue(scavengeItemDic);
    }

    private void ResourceValue(List<ResourceData> resourceListData)
    {
        foreach(ResourceData resourceData in resourceListData)
        {
            resourceAmountCounter += 1;
            resourceValueCounter += resourceData.resourceAmount;
        }
        Debug.Log($"Resouce value : {resourceValueCounter}");
        Debug.Log($"Resouce amount : {resourceAmountCounter}");
        OnResourceAmount?.Invoke(resourceValueCounter);
    }

    private void ItemValue(Dictionary<Item, byte> itemDic)
    {
        foreach (KeyValuePair<Item,byte> kvp in itemDic)
        {
            itemValueCounter += (byte)(kvp.Key.itemValue *  kvp.Value);
            itemAmountCounter +=1;
        }
        Debug.Log($"Item value counter : {itemValueCounter}");
        Debug.Log($"Item amount counter : {itemAmountCounter}");
        OnItemValue?.Invoke(itemValueCounter);
    }

    private void ResetResource()
    {
        FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        foreach(FieldInfo field in fields)
        {
            if(field != null)
            {
                if(field.FieldType == typeof(byte))
                {
                    field.SetValue(this , (byte)0);
                }
            }
        }
    }
}
