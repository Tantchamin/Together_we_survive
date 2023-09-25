using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomFrontendScript : MonoBehaviour
{
    [SerializeField] private Camera _roomCamera;
    [SerializeField] private GameObject _livingRoomBG;
    [SerializeField] private GameObject _livingRoomFrontUI;
    [SerializeField] private GameObject _eatingManageUI;
    [SerializeField] private GameObject _endDayButton;

    // Start is called before the first frame update
    void Start()
    {
        _livingRoomFrontUI = GameObject.Find("LivingRoomFrontUI");
        _eatingManageUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_roomCamera.transform.position.x == _livingRoomBG.transform.position.x)
        {
            SetLivingRoomUIActive(true);
        }
        else
        {
            SetLivingRoomUIActive(false);
        }
    }

    public void SetLivingRoomUIActive(bool _uiActive)
    {
        _livingRoomFrontUI.SetActive(_uiActive);
        _endDayButton.SetActive(_uiActive);
    }

    public void DisplayEatingManageUI(bool _isDisplay)
    {
        _eatingManageUI.SetActive(_isDisplay);
        
    }
}
