using UnityEngine;

public class MenuInitializer : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasConfirmExit;

    void Start()
    {
        canvasMenu.SetActive(true); 
        canvasConfirmExit.SetActive(false);
    }
}
