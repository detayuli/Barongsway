using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "DialogSystem/DialogData")]
public class DialogData : ScriptableObject
{
    [TextArea(3, 10)]
    public string[] sentences; // Daftar kalimat dalam satu percakapan
}