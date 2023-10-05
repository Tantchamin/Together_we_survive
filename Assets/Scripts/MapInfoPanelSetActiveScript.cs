using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfoPanelSetActiveScript : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    private GameObject Hello;
    public void SetActivePanel(){
        if(_infoPanel == null) return;
        Hello.SetActive(true);
        bool _isPanelActive = _infoPanel.activeSelf;
        _infoPanel.SetActive(!_isPanelActive);
    }
}
