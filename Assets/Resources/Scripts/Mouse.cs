using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Vector2 hotSpot;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    void OnDisable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
