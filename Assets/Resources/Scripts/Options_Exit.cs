using UnityEngine;

public class CanvasNavigation : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasOptions;

    public void ShowMenu()
    {
        canvasMenu.SetActive(true);
        canvasOptions.SetActive(false);
    }

    public void ShowOptions()
    {
        canvasMenu.SetActive(false);
        canvasOptions.SetActive(true);
    }
}