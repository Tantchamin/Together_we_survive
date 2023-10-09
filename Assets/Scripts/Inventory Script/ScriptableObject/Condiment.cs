using System;
using UnityEngine;

public class Condiment : Item
{
    public int useAmount;
    public Taste taste;
    public enum Taste
    {
        Base,
        Sour ,
        Salty,
        Sweet,
        Spicy,
    }
}