using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData, menu name = 'Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement")]
    public float movementVelocityX = 5f;
    public float movementVelocityY = 3f;
    public float jumpVelocity = 3f;
}

