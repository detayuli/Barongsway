using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogData dialogData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Mengecek apakah yang masuk area adalah Player
        if (other.CompareTag("Player") && dialogData != null && dialogData.sentences.Length > 0)
        {
            // Ambil kalimat pertama dari ScriptableObject
            DialogManager.Instance.ShowDialog(dialogData.sentences[0]);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Saat Player keluar area, dialog langsung mati
        if (other.CompareTag("Player"))
        {
            DialogManager.Instance.HideDialog();
        }
    }
}