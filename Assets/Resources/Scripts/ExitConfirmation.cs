using UnityEngine;

public class ExitConfirmation : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasConfirmExit;

    public void ShowExitConfirmation()
    {
        canvasMenu.SetActive(false);
        canvasConfirmExit.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Detiene el modo de juego en el editor de Unity
#else
        Application.Quit();
#endif
    }

    public void CancelExit()
    {
        canvasConfirmExit.SetActive(false);
        canvasMenu.SetActive(true);
    }
}
