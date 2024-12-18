using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Stamina : MonoBehaviour
{
    public Sprite[] progressSprites; // Array de sprites de la barra de progreso (porcentaje)
    public Image progressBarImage; // Imagen de la barra de progreso (UI)
    public GameObject progressButton; // Botón que aparecerá en la zona específica
    public int currentProgress = 0; // Progreso actual en porcentaje

    private int progressStep; // Cuánto aumenta el progreso con cada botón (calculado)

    void Start()
    {
        // Inicializar la barra y el botón
        currentProgress = 0;
        progressStep = 100 / (progressSprites.Length - 1); // Calcular el incremento según el número de sprites
        UpdateProgressBar();
        progressButton.SetActive(false); // Ocultar el botón al inicio
    }

    void UpdateProgressBar()
    {
        // Cambiar el sprite de la barra basado en el progreso actual
        int spriteIndex = Mathf.Clamp(currentProgress / progressStep, 0, progressSprites.Length - 1);
        progressBarImage.sprite = progressSprites[spriteIndex];
    }

    public void IncreaseProgress()
    {
        if (currentProgress < 100)
        {
            currentProgress += progressStep;
            UpdateProgressBar();
        }
    }

   void OnTriggerEnter(Collider other)
{
    Debug.Log("Objeto ingresó al triggerhnmshgmsg."); // Mensaje para verificar la activación del método
    if (other.CompareTag("Player"))
    {
        Debug.Log("Colisión detectada con la zona.");
        progressButton.SetActive(true);
    }
}

    void OnTriggerExit(Collider other)
    {
        // Ocultar el botón cuando el jugador salga de la zona
        if (other.CompareTag("Player"))
        {
            progressButton.SetActive(false);
        }
    }
}
