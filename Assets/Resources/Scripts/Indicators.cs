using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image hoverSprite1;
    public Image hoverSprite2;
    public Button button;

    private void Start()
    {
        hoverSprite1.gameObject.SetActive(false);
        hoverSprite2.gameObject.SetActive(false);
        button.onClick.AddListener(OnClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverSprite1.gameObject.SetActive(true);
        hoverSprite2.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverSprite1.gameObject.SetActive(false);
        hoverSprite2.gameObject.SetActive(false);
    }

    private void OnClick()
    {
        Debug.Log(button.name + " clicked!");
        hoverSprite1.gameObject.SetActive(false);
        hoverSprite2.gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void ResetHoverState()
    {
        hoverSprite1.gameObject.SetActive(false);
        hoverSprite2.gameObject.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
