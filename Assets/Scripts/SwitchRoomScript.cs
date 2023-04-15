using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRoomScript : MonoBehaviour
{
    public GameObject _roomCamera;

    [SerializeField] private GameObject _frontYardUI;
    [SerializeField] private GameObject _livingRoomBG, _KitchenBG, _GarageBG, _FrontYardBG;

    private void Start(){
        _frontYardUI = GameObject.Find("FrontYardUI");
        _frontYardUI.SetActive(false);
    }

    public void GoToLivingRoom()
    {
        _roomCamera.transform.position = new Vector3(_livingRoomBG.transform.position.x, 0, -15);
    }

    public void GoToKitchen()
    {
        _roomCamera.transform.position = new Vector3(_KitchenBG.transform.position.x, 0, -15);
    }

    public void GoToGarage()
    {
        _roomCamera.transform.position = new Vector3(_GarageBG.transform.position.x, 0, -15);
    }

    public void GoToFrontYard()
    {
        _frontYardUI.SetActive(true);
        _roomCamera.transform.position = new Vector3(_FrontYardBG.transform.position.x, 0, -15);
    }
}
