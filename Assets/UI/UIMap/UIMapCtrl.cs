using UnityEngine;
using UnityEngine.UI;

public class MiniMapController : MonoBehaviour
{
    public Camera mapCamera;   // ��ͼ�����
    public RawImage miniMapImage;  // С��ͼ�� Raw Image ���

    private RenderTexture mapRenderTexture;  // ��ͼ�������Ŀ������

    void Start()
    {
        // ����һ�� RenderTexture ��Ϊ��ͼ�������Ŀ������
        mapRenderTexture = new RenderTexture(Screen.width / 4, Screen.height / 4, 24);
        mapRenderTexture.Create();

        // �� RenderTexture ����Ϊ��ͼ�������Ŀ������
        mapCamera.targetTexture = mapRenderTexture;
    }

    void LateUpdate()
    {
        // ����ͼ���������Ⱦ�����ʾ��С��ͼ�� Raw Image ��
        if (mapRenderTexture != null)
        {
            miniMapImage.texture = mapRenderTexture;
        }
    }
}
