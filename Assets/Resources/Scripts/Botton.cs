using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button NewGame;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = NewGame.transform.localScale;

        NewGame.onClick.AddListener(OnNewGame);
    }

    public void OnNewGame()
    {
        StartCoroutine(AnimateButton(NewGame));
    }

    private System.Collections.IEnumerator AnimateButton(Button button)
    {
        button.transform.localScale = originalScale * 0.9f;
        yield return new WaitForSeconds(0.1f);
        button.transform.localScale = originalScale;

        SceneManager.LoadScene("Character_Plane");
    }
}