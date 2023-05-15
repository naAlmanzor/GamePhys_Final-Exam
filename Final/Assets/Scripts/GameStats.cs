using UnityEngine;

[CreateAssetMenu(fileName = "GameStats", menuName = "ScriptableObjects/GameStats", order = 1)]
public class GameStats : ScriptableObject
{
    public float wallSpeed;
    public float playerSpeed;
    public float playerSprintMultiplier;
    public float cameraSensitivity;
    public float inversionSpeed;
}
