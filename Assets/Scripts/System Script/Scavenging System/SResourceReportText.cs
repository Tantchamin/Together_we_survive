using System;
using UnityEngine;
using TMPro;
public class SResourceReportText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resourceText , itemText;
    private void OnEnable() {
        SResourceValueManager.OnResourceAmount += DisplayResourceValue;
        SResourceValueManager.OnItemValue += DisplayItemValue;
    }

    private void OnDisable() {
        SResourceValueManager.OnResourceAmount -= DisplayResourceValue;
        SResourceValueManager.OnItemValue -= DisplayItemValue;
    }

    private void DisplayResourceValue(byte resourceValue)
    {
        switch(resourceValue)
        {
            case 0 : 
                resourceText.text = "Unfortunately we didn't found any resources tonight";
                break;
            case <= 5 :
                resourceText.text = "Few resources were found tonight , roughly night";
                break;
            case <= 10 :
                resourceText.text = "We found some useful stuff tonight!";
                break;
            case <= 15 :
                resourceText.text = "Tonight we found a lot of resources! ";
                break;
            case <= 20 :
                resourceText.text = "Lucky night! we found tons of plentiful resources";
                break;
            case > 20 :
                resourceText.text = "Fascinating! huge amount of resources we found tonight";
                break;
        }
    }
    private void DisplayItemValue(byte itemValue)
    {
        switch(itemValue)
        {
            case 0 :
                itemText.text = "We didn't found single item tonight!";
                break;
            case <= 5 :
                itemText.text = "Meh, a few item were found hopefully it's useful";
                break;
            case <= 10 :
                itemText.text = "That's some useful item we found right here!";
                break;
            case <= 15 :
                itemText.text = "Lovely!, we found a lot of good item";
                break;
            case <= 20 :
                itemText.text = "Fourtunate night! , we found tons of valuable item!";
                break;
            case > 20 :
                itemText.text = "unbelievable, this is how we will survive apocalypse";
                break; 
        }
    }
}
