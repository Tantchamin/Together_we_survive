using System;
using UnityEngine;

public class SwitchRoomScript : MonoBehaviour
{
    public GameObject _roomCamera;

    [SerializeField] private GameObject _frontYardUI;
    [SerializeField] private GameObject _livingRoomBG, _KitchenBG, _GarageBG, _FrontYardBG;

    public static event Action OnEnterKitchen , OnEnterLivingRoom , OnEnterGarage , OnEnterFrontYard , OnLeave;

    private void Start() {
        OnLeave?.Invoke();
        OnEnterLivingRoom?.Invoke();
    }

    public void GoToLivingRoom()
    {
        OnLeave?.Invoke();
        _roomCamera.transform.position = new Vector3(_livingRoomBG.transform.position.x, 0, -15);
        OnEnterLivingRoom?.Invoke();
    }

    public void GoToKitchen()
    {
        OnLeave?.Invoke();
        _roomCamera.transform.position = new Vector3(_KitchenBG.transform.position.x, 0, -15);
        OnEnterKitchen?.Invoke();
    }

    public void GoToGarage()
    {
        OnLeave?.Invoke();
        _roomCamera.transform.position = new Vector3(_GarageBG.transform.position.x, 0, -15);
        OnEnterGarage?.Invoke();
    }
    public void GoToFrontYard()
    {
        OnLeave?.Invoke();
        _roomCamera.transform.position = new Vector3(_FrontYardBG.transform.position.x, 0, -15);
        OnEnterFrontYard?.Invoke();
    }
}
