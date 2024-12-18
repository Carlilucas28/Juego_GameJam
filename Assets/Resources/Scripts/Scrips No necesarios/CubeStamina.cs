using UnityEngine;
using UnityEngine.UI;

public class StaminaCube : MonoBehaviour
{
    public Button staminaButton;
    public StaminaManager staminaManager;
    private bool playerInRange = false;

    private void Start()
    {
        staminaButton.gameObject.SetActive(false);
        staminaButton.onClick.AddListener(OnStaminaButtonClick);
    }

    private void Update()
    {
        staminaButton.gameObject.SetActive(playerInRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void OnStaminaButtonClick()
    {
        staminaManager.AddStamina();
    }
}
