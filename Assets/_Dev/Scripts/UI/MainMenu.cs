using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void toLevelSelect()
    {
        Debug.Log("Start Game button clicked. Loading Level Select scene...");
        SceneManager.LoadScene("LevelSelect");
        audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game button clicked.");
        audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
        // Add logic to quit the game
        Application.Quit();
    }

    public void SelectLevel(LevelDataSO levelData)
    {
        SceneManager.LoadScene(levelData.sceneName);
        audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
    }

    public void CreditScene()
    {
        // SceneManager.LoadScene("CreditScene");
        audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
    }
}
