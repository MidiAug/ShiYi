using UnityEngine;
using UnityEngine.UI;

public class MiniMapController : MonoBehaviour
{
    public Camera mapCamera;   // 地图摄像机
    public RawImage miniMapImage;  // 小地图的 Raw Image 组件

    private RenderTexture mapRenderTexture;  // 地图摄像机的目标纹理

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
        // 将地图摄像机的渲染结果显示在小地图的 Raw Image 上
        if (mapRenderTexture != null)
        {
            miniMapImage.texture = mapRenderTexture;
        }
    }
}
