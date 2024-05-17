using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnclickTaiwan2 : MonoBehaviour

{
    public GameObject chose1Image; // ���ڴ洢Chose1��Image����
    public GameObject choseText;//��ʾtext
    private bool isMouseOver = false;
    void Start()
    {
        // ȷ��Chose1ͼ���ڿ�ʼʱ�����ص�
        if (chose1Image != null)
        {
            chose1Image.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Chose1 image is not assigned.");
        }
        choseText.SetActive(false);
    }

    // �������밴ťʱ���ô˷���
    public void OnPointerEnter()
    {
        if (chose1Image != null && !isMouseOver)
        {
            chose1Image.SetActive(true);
            isMouseOver = true;
            choseText.SetActive(true);
            isMouseOver = true;
        }
        
    }

    // ������뿪��ťʱ���ô˷���
    public void OnPointerExit()
    {
        if (chose1Image != null && isMouseOver)
        {
            chose1Image.SetActive(false);
            isMouseOver = false;
            choseText.SetActive(false);
            isMouseOver = false;
        }
        
    }
}
