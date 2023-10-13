using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomUIManager : MonoBehaviour
{
    [SerializeField] private GameObject livingRoomBG, livingRoomFrontUI, eatingManageUI, endDayButton
    , temperatureText , dayText , furnanceUIButton; 

    // Start is called before the first frame update
    void Start()
    {
        eatingManageUI.SetActive(false);
    }

    private void OnEnable() {
        SwitchRoomScript.OnEnterLivingRoom += EnterLivingRoom;
        SwitchRoomScript.OnLeave += LeveLivingRoom;
    }
    private void OnDisable() {
        SwitchRoomScript.OnEnterLivingRoom -= EnterLivingRoom;
        SwitchRoomScript.OnLeave -= LeveLivingRoom;
    }

    
    private void EnterLivingRoom()
    {
        SetLivingRoomUIActive(true);
    }

    private void LeveLivingRoom()
    {
        SetLivingRoomUIActive(false);
    }

    public void SetLivingRoomUIActive(bool _uiActive)
    {
        livingRoomFrontUI.SetActive(_uiActive);
        endDayButton.SetActive(_uiActive);
        temperatureText.SetActive(_uiActive);
        dayText.SetActive(_uiActive);
        furnanceUIButton.SetActive(_uiActive);
    }

    public void DisplayEatingManageUI(bool _isDisplay)
    {
        eatingManageUI.SetActive(_isDisplay);
        
    }
}
