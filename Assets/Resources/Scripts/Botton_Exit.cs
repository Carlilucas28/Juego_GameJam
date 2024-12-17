using UnityEngine;

public class Botton_Exit : MonoBehaviour
{
    public void SalirDelJuego()
    {
        Debug.Log("El juego se está cerrando...");

#if UNITY_EDITOR
            // Esta línea detiene el modo de juego en Unity Editor
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
