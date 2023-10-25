using UnityEngine;
[CreateAssetMenu(fileName = "Event", menuName = "SeniorProjectGame/Event/PassiveEvent", order = 0)]

public class PassiveEvent : RandomEvent
{
    public byte damageRequired;
    public byte stateLoses;

    public byte resoueceLoses;
}
