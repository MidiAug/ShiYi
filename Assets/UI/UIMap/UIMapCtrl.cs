using UnityEngine;
using UnityEngine.UI;

public class MiniMapController : MonoBehaviour
{
    public float worldUpLimit;    // �����������������
    public float worldDownLimit;  // �����������������
    public float worldLeftLimit;  // �����������������
    public float worldRightLimit; // �����������������
    public Transform target;      // Ҫ�����Ŀ�꣬������ҽ�ɫ
    public Camera mapCamera;      // ��ͼ�����
    public RawImage miniMapImage; // С��ͼ�� Raw Image ���

    private RenderTexture mapRenderTexture; // ��ͼ�������Ŀ������

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
        // ���û��Ŀ�ֱ꣬�ӷ���
        if (target == null)
            return;

        // ��ȡĿ���λ��
        Vector3 targetPosition = target.position;

        // �����������λ�ò�����ָ�����������귶Χ
        float clampedX = Mathf.Clamp(targetPosition.x, worldLeftLimit, worldRightLimit);
        float clampedY = Mathf.Clamp(targetPosition.y, worldDownLimit, worldUpLimit);

        // ��ȡ�������ǰλ��
        Vector3 currentCameraPos = mapCamera.transform.position;

        // �������������λ�ã����� Z ���겻�䣩
        Vector3 newPosition = new Vector3(clampedX, clampedY, currentCameraPos.z);
        mapCamera.transform.position = newPosition;

        // ����ͼ���������Ⱦ�����ʾ��С��ͼ�� Raw Image ��
        if (mapRenderTexture != null)
        {
            miniMapImage.texture = mapRenderTexture;
        }
    }
}
