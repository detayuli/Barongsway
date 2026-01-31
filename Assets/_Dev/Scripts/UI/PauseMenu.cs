using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject pauseMenuUI;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        //audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
        pauseButton.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        //audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
        pauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        //audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        //audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
        SceneManager.LoadScene("MainMenu");
    }
}
