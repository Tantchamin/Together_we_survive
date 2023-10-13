using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "SeniorProjectGame/Event", order = 0)]
public class Event : ScriptableObject 
{
    public string eventName;
    public string eventDescription;
    public string goodEndingDescription;
    public string badEndingDescription;

    public byte ammoGain;
    public byte foodGain;
    public byte medicineGain;
    public byte waterGain;

}
