using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MenuController : MonoBehaviour
{
    public GameObject logoPanel;
    public GameObject menuButtonsPanel; 
    public TextMeshProUGUI pressAnyKeyText;
    public float fadeSpeed = 2f;
    public float transitionDuration = 1f;
    public Camera mainCamera;
    public Transform targetPosition;

    private bool isAnyKeyPressed = false;
    private Vector3 originalCameraPosition;
    private float originalCameraFOV;

    private void Start()
    {
        pressAnyKeyText.enabled = true;
        menuButtonsPanel.SetActive(false);
        originalCameraPosition = mainCamera.transform.position;
        originalCameraFOV = mainCamera.fieldOfView;

        StartCoroutine(TextBlinkEffect());
    }

    private void Update()
    {
        if (!isAnyKeyPressed && Input.anyKeyDown)
        {
            isAnyKeyPressed = true;
            StopCoroutine(TextBlinkEffect());
            pressAnyKeyText.enabled = false;
            StartCoroutine(ZoomToShowMenu());
        }
    }

    private IEnumerator TextBlinkEffect()
    {
        Color originalColor = pressAnyKeyText.color;
        while (!isAnyKeyPressed)
        {
            pressAnyKeyText.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.PingPong(Time.time * fadeSpeed, 1f));
            yield return null;
        }
        pressAnyKeyText.color = originalColor;
    }

    private IEnumerator ZoomToShowMenu()
    {
        logoPanel.SetActive(false);

        menuButtonsPanel.SetActive(true);

        float elapsedTime = 0f;
        Vector3 startPosition = originalCameraPosition;
        float startFOV = originalCameraFOV;

        while (elapsedTime < transitionDuration)
        {
            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition.position, elapsedTime / transitionDuration);
            mainCamera.fieldOfView = Mathf.Lerp(startFOV, 30f, elapsedTime / transitionDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = targetPosition.position;
        mainCamera.fieldOfView = 30f;

    }
}

