using UnityEngine;
using System.Collections;
public class Test : MonoBehaviour
{
    public GameObject objectToShow; // 需要显示的子物体
    public float delayBeforeHide = 1.0f; // 延迟隐藏的时间

    private Coroutine hideCoroutine; // 用于延迟隐藏的协程

    void Start()
    {
        // 初始时隐藏子物体
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

    public void ShowObject()
    {
        // 显示子物体
        if (objectToShow != null)
        {
            objectToShow.SetActive(true);
            // 取消之前的延迟隐藏协程
            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
            }
        }
    }

    public void HideObject()
    {
        // 延迟隐藏子物体
        if (objectToShow != null)
        {
            // 启动延迟隐藏协程
            hideCoroutine = StartCoroutine(DelayHideObject());
        }
    }

    private IEnumerator DelayHideObject()
    {
        // 等待一段时间后隐藏子物体
        yield return new WaitForSeconds(delayBeforeHide);
        objectToShow.SetActive(false);
    }
}
