using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    // Referencias al Text UI, Button, y Canvases
    public Text dialogText;  // Referencia al Text UI que mostrará el diálogo
    public Button nextButton;  // Referencia al Button UI
    public Canvas CanvaScene1;  // Canvas inicial
    public Canvas CanvaScene2;  // Canvas final
    public Image dialogImage;   // Referencia al Image UI para mostrar imágenes

    // Arrays con las líneas del diálogo y las imágenes correspondientes
    public string[] dialogLines;
    public Sprite[] dialogSprites;

    // Índice para rastrear la línea actual
    private int currentLineIndex = 0;

    void Start()
    {
        // Asegurarte de que el segundo canvas esté oculto al inicio
        CanvaScene2.gameObject.SetActive(false);

        // Configurar la primera línea de diálogo e imagen
        if (dialogLines.Length > 0)
        {
            dialogText.text = dialogLines[currentLineIndex];
        }

        if (dialogSprites.Length > 0 && dialogSprites[currentLineIndex] != null)
        {
            dialogImage.sprite = dialogSprites[currentLineIndex];
            dialogImage.gameObject.SetActive(true);  // Mostrar la imagen
        }
        else
        {
            dialogImage.gameObject.SetActive(false);  // Ocultar si no hay imagen
        }

        // Asignar la función al botón
        nextButton.onClick.AddListener(DisplayNextLine);
    }

    // Método para cambiar el texto y la imagen cuando se presiona el botón
    void DisplayNextLine()
    {
        currentLineIndex++;  // Avanzar a la siguiente línea

        if (currentLineIndex < dialogLines.Length)
        {
            // Actualizar el texto
            dialogText.text = dialogLines[currentLineIndex];

            // Actualizar la imagen correspondiente
            if (dialogSprites.Length > currentLineIndex && dialogSprites[currentLineIndex] != null)
            {
                dialogImage.sprite = dialogSprites[currentLineIndex];
                dialogImage.gameObject.SetActive(true);  // Mostrar la imagen
            }
            else
            {
                dialogImage.gameObject.SetActive(false);  // Ocultar si no hay imagen
            }
        }
        else
        {
            // Fin del diálogo: ocultar el botón, cambiar de Canvas
            nextButton.gameObject.SetActive(false);
            CanvaScene1.gameObject.SetActive(false);
            CanvaScene2.gameObject.SetActive(true);

            dialogText.text = "Fin del diálogo.";  // Mensaje final
            dialogImage.gameObject.SetActive(false);  // Opcional: ocultar la imagen
        }
    }
}
