using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToMenu : MonoBehaviour
{
    public GameObject CanvasPause;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CanvasPause.SetActive(true);
        }
    }
    public void LoadHome()
    {
        SceneManager.LoadScene("Homescreen");
    }
}
