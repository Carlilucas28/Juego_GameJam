using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject hudCanvas;
    public Slider volumeSlider;
    public TMP_Dropdown languageDropdown;
    private bool isPaused = false;

    private void Start()
    {
        pauseMenuCanvas.SetActive(false);
        hudCanvas.SetActive(true);
        volumeSlider.value = AudioListener.volume;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenuCanvas.SetActive(true);
        hudCanvas.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuCanvas.SetActive(false);
        hudCanvas.SetActive(true);
    }

    public void OnVolumeChanged()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void OnLanguageChanged(int index)
    {
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
