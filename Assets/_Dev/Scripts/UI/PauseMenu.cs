using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
        gameObject.SetActive(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        audiomanager.Instance.PlaySFX(audiomanager.Instance.buttonClick);
        SceneManager.LoadScene("MainMenu");
    }
}
