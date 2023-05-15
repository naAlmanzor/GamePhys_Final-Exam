using UnityEngine;

[CreateAssetMenu(fileName = "TimeData", menuName = "ScriptableObjects/TimeData", order = 1)]
public class TimeData : ScriptableObject
{
    public int minutes;
    public int seconds;
    public int milliseconds;

}
