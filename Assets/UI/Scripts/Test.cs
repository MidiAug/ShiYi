using UnityEngine;
using System.Collections;
public class Test : MonoBehaviour
{
    public GameObject objectToShow; // ��Ҫ��ʾ��������
    public float delayBeforeHide = 1.0f; // �ӳ����ص�ʱ��

    private Coroutine hideCoroutine; // �����ӳ����ص�Э��

    void Start()
    {
        // ��ʼʱ����������
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

    public void ShowObject()
    {
        // ��ʾ������
        if (objectToShow != null)
        {
            objectToShow.SetActive(true);
            // ȡ��֮ǰ���ӳ�����Э��
            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
            }
        }
    }

    public void HideObject()
    {
        // �ӳ�����������
        if (objectToShow != null)
        {
            // �����ӳ�����Э��
            hideCoroutine = StartCoroutine(DelayHideObject());
        }
    }

    private IEnumerator DelayHideObject()
    {
        // �ȴ�һ��ʱ�������������
        yield return new WaitForSeconds(delayBeforeHide);
        objectToShow.SetActive(false);
    }
}
