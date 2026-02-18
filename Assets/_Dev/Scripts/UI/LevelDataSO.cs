using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Level Data")]
public class LevelDataSO : ScriptableObject
{
    [Header("Level Information")]
    public string levelDisplayName;
    public string sceneName;

    // public bool isLocked;
}