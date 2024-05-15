using UnityEngine;
using UnityEngine.UI;

public class MiniMapController : MonoBehaviour
{
    public float worldUpLimit;    // 世界坐标的视线上限
    public float worldDownLimit;  // 世界坐标的视线下限
    public float worldLeftLimit;  // 世界坐标的视线左限
    public float worldRightLimit; // 世界坐标的视线右限
    public Transform target;      // 要跟随的目标，比如玩家角色
    public Camera mapCamera;      // 地图摄像机
    public RawImage miniMapImage; // 小地图的 Raw Image 组件

    private RenderTexture mapRenderTexture; // 地图摄像机的目标纹理

    void Start()
    {
        // 创建一个 RenderTexture 作为地图摄像机的目标纹理
        mapRenderTexture = new RenderTexture(Screen.width / 4, Screen.height / 4, 24);
        mapRenderTexture.Create();

        // 将 RenderTexture 设置为地图摄像机的目标纹理
        mapCamera.targetTexture = mapRenderTexture;
    }

    void LateUpdate()
    {
        // 如果没有目标，直接返回
        if (target == null)
            return;

        // 获取目标的位置
        Vector3 targetPosition = target.position;

        // 限制摄像机的位置不超过指定的世界坐标范围
        float clampedX = Mathf.Clamp(targetPosition.x, worldLeftLimit, worldRightLimit);
        float clampedY = Mathf.Clamp(targetPosition.y, worldDownLimit, worldUpLimit);

        // 获取摄像机当前位置
        Vector3 currentCameraPos = mapCamera.transform.position;

        // 设置摄像机的新位置（保持 Z 坐标不变）
        Vector3 newPosition = new Vector3(clampedX, clampedY, currentCameraPos.z);
        mapCamera.transform.position = newPosition;

        // 将地图摄像机的渲染结果显示在小地图的 Raw Image 上
        if (mapRenderTexture != null)
        {
            miniMapImage.texture = mapRenderTexture;
        }
    }
}
