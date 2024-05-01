using UnityEngine;

public class MouseCursorChanger : MonoBehaviour
{
    public Texture2D cursorTexture; // ������ָ��ͼ��
    public CursorMode cursorMode = CursorMode.Auto; // �������ָ��ģʽ
    public Vector2 hotSpot = Vector2.zero; // �������ָ���ȵ�λ��

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode); // �������ָ��ͼ��
    }
}
