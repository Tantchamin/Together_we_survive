using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventScript : MonoBehaviour
{
    public static event Action onGarageResourceButtonClicked;


    public void OnThisButtonClicked(){
        onGarageResourceButtonClicked?.Invoke();
    }
}
