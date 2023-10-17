using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUIUpdateManager : MonoBehaviour
{
    [SerializeField] private ChooseCharacterManager chooseCharacterManager;

    private void Start() {
        chooseCharacterManager.enabled =false;
    }
    public void SwitchCharacterToogle()
    {
        chooseCharacterManager.enabled = !chooseCharacterManager.isActiveAndEnabled;
    }

}
