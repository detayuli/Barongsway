using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    [Header("UI References")]
    public GameObject dialogPanel; // Tarik objek "Tutorial1" ke sini
    public TextMeshProUGUI dialogText; // Tarik objek "Tutorial1text" ke sini

    void Awake() 
    { 
        Instance = this; 
        // Pastikan di awal game dialognya mati
        if(dialogPanel != null) dialogPanel.SetActive(false);
    }

    public void ShowDialog(string text)
    {
        if (dialogPanel == null) return;

        dialogPanel.SetActive(true);
        dialogText.text = text;
    }

    public void HideDialog()
    {
        if (dialogPanel == null) return;
        dialogPanel.SetActive(false);
    }
}