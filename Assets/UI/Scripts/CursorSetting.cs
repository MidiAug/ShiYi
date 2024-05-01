using UnityEngine;

public class MouseCursorChanger : MonoBehaviour
{
    public Texture2D cursorTexture; // 你的鼠标指针图标
    public CursorMode cursorMode = CursorMode.Auto; // 设置鼠标指针模式
    public Vector2 hotSpot = Vector2.zero; // 设置鼠标指针热点位置

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode); // 设置鼠标指针图标
    }
}
