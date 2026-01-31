using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
        audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game button clicked.");
        audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
        // Add logic to quit the game
        Application.Quit();
    }
}
