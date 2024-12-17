using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContadorMonedas  : MonoBehaviour
{
    public int coinCount = 0; // Contador de monedas
    public TextMeshProUGUI coinText; // Texto de UI para mostrar el contador de monedas

    void Start()
    {
        UpdateCoinUI(); // Actualiza la UI al iniciar el juego
    }

    public void CollectCoin()
    {
        coinCount++; // Incrementa el contador de monedas
        UpdateCoinUI(); // Actualiza la UI
    }

    void UpdateCoinUI()
    {
        coinText.text = "" + coinCount; // Actualiza el texto de UI
    }
}
