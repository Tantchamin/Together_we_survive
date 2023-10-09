using System;
using UnityEngine;

public abstract class Bonfire : MonoBehaviour
{
    public abstract void AddFuel(Fuel fuel);
    public abstract void ToggleOnOff();
    
}
