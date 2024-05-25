using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // 玩家 Transform
    public Vector3 offset;   // 相机与玩家的偏移
    public float smoothSpeed = 0.125f; // 平滑速度

    private void LateUpdate()
    {
        // 目标位置：玩家位置 + 偏移
        Vector3 desiredPosition = player.position + offset;
        // 平滑移动到目标位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;

        // 保持相机朝向玩家
/*        transform.LookAt(player);
*/    }
}
