using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpecialEffect : MonoBehaviour
{
    // 控制本体的几个参数
    public float darkenPercentage = 0.5f; // 变深的百分比
    public float scaleRatio = 0.9f; // 缩小的比例
    public float transitionSpeed = 5f; // 过渡速度
    private Image buttonImage;
    private Vector3 originalScale;
    private bool isPressed = false;
    private Color originalColor;

    //控制周围特效的参数
    public Image image;
    public float scaleRatio2 = 0.9f; // 放大的比例
    public float transitionSpeed2 = 5f; // 过渡速度
    public bool release = false;
    private Color originalColor2;
    private Vector3 originalScale2;



    private bool ban = false;


    void Start()
    {
        buttonImage = GetComponent<Image>(); // 获取按钮的Image组件
        originalScale = transform.localScale; // 记录按钮的原始缩放比例
        originalColor = buttonImage.color; // 记录按钮的原始颜色

        originalScale2 = image.transform.localScale; // 记录特效的原始缩放比例
        originalColor2 = image.color; // 记录特效的原始颜色

        image.gameObject.SetActive(false);
    }

    void Update()
    {
        // 特效结束判定
        if(image.color.a < 0.5f)
        {
            release = false;
        }

        // 按住按键 L 时触发效果
        if (Input.GetKeyDown(KeyCode.L))
        {
            isPressed = true;
        }

        // 松开按键 L 时恢复原状
        if (Input.GetKeyUp(KeyCode.L))
        {
            isPressed = false;
            release = true;
        }

        if (!ban)
        {
            // 根据按键状态逐渐变化效果
            if (isPressed)
            {
                // 改变按钮的颜色为变深后的颜色
                buttonImage.color = Color.Lerp(buttonImage.color, originalColor * (1 - darkenPercentage), Time.deltaTime * transitionSpeed);
                // 缩小按钮的大小
                transform.localScale = Vector3.Lerp(transform.localScale, originalScale * scaleRatio, Time.deltaTime * transitionSpeed);
            }
            else
            {
                // 恢复按钮的原始颜色
                buttonImage.color = Color.Lerp(buttonImage.color, originalColor, Time.deltaTime * transitionSpeed);
                // 恢复按钮的原始大小
                transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * transitionSpeed);
            }

            if (release)
            {
                image.gameObject.SetActive(true);
                image.color = Color.Lerp(image.color, new Color(1, 1, 1, 0), Time.deltaTime * transitionSpeed2);
                image.transform.localScale = Vector3.Lerp(image.transform.localScale, originalScale2 * scaleRatio2, Time.deltaTime * transitionSpeed2);
            }
            else
            {
                // 恢复初始状态
                image.gameObject.SetActive(false);
                image.color = originalColor2;
                image.transform.localScale = originalScale2;
            }
        }

        else
        {
            buttonImage.color = Color.Lerp(buttonImage.color, originalColor * (1 - darkenPercentage), Time.deltaTime * transitionSpeed);
            // 恢复初始状态
            image.gameObject.SetActive(false);
            image.color = originalColor2;
            image.transform.localScale = originalScale2;
        }
    }
    public void banTheSkill() { ban = true; }

}

