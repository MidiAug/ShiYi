using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // ��� Transform
    public Vector3 offset;   // �������ҵ�ƫ��
    public float smoothSpeed = 0.125f; // ƽ���ٶ�

    private void LateUpdate()
    {
        // Ŀ��λ�ã����λ�� + ƫ��
        Vector3 desiredPosition = player.position + offset;
        // ƽ���ƶ���Ŀ��λ��
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;

        // ��������������
/*        transform.LookAt(player);
*/    }
}
