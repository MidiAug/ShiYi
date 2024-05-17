using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnclickTaiwan2 : MonoBehaviour

{
    public GameObject chose1Image; // 用于存储Chose1的Image对象
    public GameObject choseText;//显示text
    private bool isMouseOver = false;
    void Start()
    {
        // 确保Chose1图像在开始时是隐藏的
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

    // 当鼠标进入按钮时调用此方法
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

    // 当鼠标离开按钮时调用此方法
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
