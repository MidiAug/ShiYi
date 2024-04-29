using System.Collections;
using UnityEngine;

public class MovedTrap : MonoBehaviour
{
    private bool isExpanded = true; // �����Ƿ���չ����
    private Coroutine scalingCoroutine; // ���ڱ��浱ǰЭ��

    void Start()
    {
        // ÿ�������л����������״̬
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
            StopCoroutine(scalingCoroutine); // ֹͣЭ��
        }
        scalingCoroutine = StartCoroutine(ScaleTrap(isExpanded ? 1f : 0f)); // �����µ�Э��
        isExpanded = !isExpanded; // �л�����״̬
    }

    IEnumerator ScaleTrap(float targetScale)
    {
        Vector3 initialScale = transform.localScale;
        Vector3 initialPosition = transform.position;
        Vector3 targetSize = new Vector3(targetScale, targetScale, 1f);
        float duration = 0.5f; // ���Ŷ�������ʱ��
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetSize, elapsedTime / duration);
            // ����Сʱ���ƶ�����λ�ã����ֵײ�����
            Vector3 newPosition = Vector3.Lerp(initialPosition, initialPosition + Vector3.down * (initialScale.y - targetScale), elapsedTime / duration);
            transform.position = newPosition;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetSize;
        transform.position = initialPosition + Vector3.down * (initialScale.y - targetScale);
    }
}
