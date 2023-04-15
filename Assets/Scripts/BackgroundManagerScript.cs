using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class BackgroundManagerScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _livingRoomBG, _KitchenBG, _garageBG, _frontYardBG;
    [SerializeField] private  List<Sprite> _livingRoomSprites;
    [SerializeField] private  List<Sprite> _kitchenSprites;
    [SerializeField] private  List<Sprite> _garageSprites;
    [SerializeField] private  List<Sprite> _frontYardSprites;
    private int _houseLevel = -1;
    private void Start()
    {
        DisplayHouseLevel(_houseLevel);
    }

    public void UpgradeHouse(){
        DisplayHouseLevel(_houseLevel);
    }

    private void DisplayHouseLevel(int _level)
    {
        _level = _houseLevel +=1;
        Debug.Log(_level);
        _livingRoomBG.sprite = _livingRoomSprites[_level];
        _KitchenBG.sprite = _kitchenSprites[_level];
        _garageBG.sprite = _garageSprites[_level];
        _frontYardBG.sprite = _frontYardSprites[_level];
        _houseLevel = _level;
    }

}
