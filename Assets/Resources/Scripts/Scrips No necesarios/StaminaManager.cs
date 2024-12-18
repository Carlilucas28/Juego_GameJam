using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public Image staminaImage;
    private int currentStaminaIndex = 0;
    private int maxStaminaIndex = 4;

    private void Start()
    {
        UpdateStamina();
    }

    public void AddStamina()
    {
        currentStaminaIndex++;
        if (currentStaminaIndex > maxStaminaIndex)
        {
            currentStaminaIndex = 0;
        }
        UpdateStamina();
    }

    private void UpdateStamina()
    {
        Sprite newSprite = Resources.Load<Sprite>($"Sprites/Stamina/{currentStaminaIndex * 25}");

        if (newSprite != null)
        {
            staminaImage.sprite = newSprite;
        }
        else
        {
            Debug.LogError($"No se pudo cargar el sprite: Sprites/Stamina/{currentStaminaIndex * 25}");
        }
    }
}
