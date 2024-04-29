using System.Collections;
using UnityEngine;

public class MovedTrap : MonoBehaviour
{
    private bool isExpanded = true; // 陷阱是否伸展出来
    private Coroutine scalingCoroutine; // 用于保存当前协程

    void Start()
    {
        // 每隔两秒切换陷阱的伸缩状态
        InvokeRepeating("ToggleTrap", 0f, 1f);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (isExpanded)
        {
            Playercontroller pc = other.GetComponent<Playercontroller>();
            if (pc != null)
            {
                pc.changeHealth(-5);
            }
        }
    }

    void ToggleTrap()
    {
        if (scalingCoroutine != null)
        {
            StopCoroutine(scalingCoroutine); // 停止协程
        }
        scalingCoroutine = StartCoroutine(ScaleTrap(isExpanded ? 1f : 0f)); // 启动新的协程
        isExpanded = !isExpanded; // 切换陷阱状态
    }

    IEnumerator ScaleTrap(float targetScale)
    {
        Vector3 initialScale = transform.localScale;
        Vector3 initialPosition = transform.position;
        Vector3 targetSize = new Vector3(targetScale, targetScale, 1f);
        float duration = 0.5f; // 缩放动画持续时间
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetSize, elapsedTime / duration);
            // 在缩小时逐渐移动陷阱位置，保持底部不变
            Vector3 newPosition = Vector3.Lerp(initialPosition, initialPosition + Vector3.down * (initialScale.y - targetScale), elapsedTime / duration);
            transform.position = newPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetSize;
        transform.position = initialPosition + Vector3.down * (initialScale.y - targetScale);
    }
}
