using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionScript : MonoBehaviour
{
    public GameObject roomCamera;
    public GameObject livingRoomBG, KitchenBG, GarageBG, FrontYardBG;

    public void GoToLivingRoom()
    {
        roomCamera.transform.position = new Vector3(livingRoomBG.transform.position.x, 0, -15);
    }

    public void GoToKitchen()
    {
        roomCamera.transform.position = new Vector3(KitchenBG.transform.position.x, 0, -15);
    }

    public void GoToGarage()
    {
        roomCamera.transform.position = new Vector3(GarageBG.transform.position.x, 0, -15);
    }

    public void GoToFrontYard()
    {
            roomCamera.transform.position = new Vector3(FrontYardBG.transform.position.x, 0, -15);
    }
}
