using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfoPanelSetActiveScript : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    public void SetActivePanel(){
        if(_infoPanel == null) return;
        bool _isPanelActive = _infoPanel.activeSelf;
        _infoPanel.SetActive(!_isPanelActive);
    }

}
