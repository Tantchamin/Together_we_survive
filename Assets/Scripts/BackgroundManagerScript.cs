using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class BackgroundManagerScript : MonoBehaviour
{
    public SpriteRenderer livingRoomBG, KitchenBG, garageBG, frontYardBG;
    public List<Sprite> livingRoomSprites;
    public List<Sprite> kitchenSprites;
    public List<Sprite> garageSprites;
    public List<Sprite> frontYardSprites;
    public int houseLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        livingRoomBG.sprite = livingRoomSprites[0];
        KitchenBG.sprite = kitchenSprites[0];
        garageBG.sprite = garageSprites[0];
        frontYardBG.sprite = frontYardSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        //if(houseLevel == 0)
        //{
        //    livingRoomBG.sprite = livingRoomSprites[0];
        //    KitchenBG.sprite = kitchenSprites[0];
        //    garageBG.sprite = garageSprites[0];
        //    frontYardBG.sprite = frontYardSprites[0];
        //}
        //else if (houseLevel == 1)
        //{
        //    livingRoomBG.sprite = livingRoomSprites[1];
        //    KitchenBG.sprite = kitchenSprites[1];
        //    garageBG.sprite = garageSprites[1];
        //    frontYardBG.sprite = frontYardSprites[1];
        //}
        //else if (houseLevel == 2)
        //{
        //    livingRoomBG.sprite = livingRoomSprites[2];
        //    KitchenBG.sprite = kitchenSprites[2];
        //    garageBG.sprite = garageSprites[2];
        //    frontYardBG.sprite = frontYardSprites[2];
        //}
        //else if (houseLevel == 3)
        //{
        //    livingRoomBG.sprite = livingRoomSprites[3];
        //    KitchenBG.sprite = kitchenSprites[3];
        //    garageBG.sprite = garageSprites[3];
        //    frontYardBG.sprite = frontYardSprites[3];
        //}
        ChangeRoomBackground(houseLevel);
    }

    private void ChangeRoomBackground(int level)
    {
        livingRoomBG.sprite = livingRoomSprites[level];
        KitchenBG.sprite = kitchenSprites[level];
        garageBG.sprite = garageSprites[level];
        frontYardBG.sprite = frontYardSprites[level];
    }
}
