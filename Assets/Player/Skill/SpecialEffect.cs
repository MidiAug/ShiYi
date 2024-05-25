using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpecialEffect : MonoBehaviour
{
    // 对白色圆形的控制
    public float drakPercentage = 0.3f; //变暗的百分比
    public float scaleRatio1 = 0.7f; // 变形大小
    public float speed1 = 5f;
    private Image whiteCircle;
    private Vector3 originalScale1;
    private Color originalColor1;

    // 周围的圈圈,旋转,变色，大小不断变
    public GameObject roundObject;
    private Image round;
    public float roundRadiusRatio;
    public float speed2;
    private Vector3 originalScale2;
    private Color originalColor2;

    // 周围的茶杯
    public GameObject cupObject;
    private Image cup;


    private bool isBan = false;    // 技能能使用
    private bool isUsing = false; // 使用技能中（释放黑影）
    private bool isPressed = false; // 是否按下键位
    private bool release = false; // 释放技能
    private float lastTime = 0f;
    public float maxLastTime;
    private bool end = true;

    public void banTheSkill() { isBan = true; }

    private void Start()
    {
        whiteCircle = GetComponent<Image>();
        originalScale1 = transform.localScale;
        originalColor1 = Color.white;
        whiteCircle.color = Color.white;

        round = roundObject.GetComponent<Image>();
        originalScale2 = roundObject.transform.localScale;
        roundObject.transform.localScale = roundObject.transform.localScale * roundRadiusRatio * 2;
        round.color = new Color(1, 1, 1, 0);
        originalColor2 = round.color;

        cup = cupObject.GetComponent<Image>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            isPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            if (isUsing) release = true;
            isUsing = !isUsing;
            isPressed = false;
        }


        if (!isBan) // 技能可以使用
        {
            if (!isUsing) // 未处于释放黑影的状态
            {

                if (isPressed) // 按下技能键
                {
                    whiteCircle.color = Color.Lerp(whiteCircle.color, originalColor1 * drakPercentage, Time.deltaTime * speed1);
                    transform.localScale = Vector3.Lerp(transform.localScale, originalScale1 * scaleRatio1, Time.deltaTime * speed1);

                    round.transform.localScale = Vector3.Lerp(round.transform.localScale, originalScale2, Time.deltaTime * speed1 * 3);
                    round.color = Color.Lerp(round.color, Color.white, Time.deltaTime * speed1 * 2);
                }
                else
                {
                    if (release) // 回归黑影位置
                    {
                        lastTime = 0f;
                        StartCoroutine(endEffect());
                        release = false;
                    }
                }
            }

            else // 释放黑影的状态
            {
                if (!isPressed) //黑影状态下的技能样式
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, originalScale1, Time.deltaTime * speed1);
                    whiteCircle.color = Color.Lerp(whiteCircle.color, new Color(240 / 255.0f, 240 / 255.0f, 210 / 255.0f), Time.deltaTime * speed1);
                    cup.color = Color.Lerp(cup.color, new Color(240 / 255.0f, 240 / 255.0f, 210 / 255.0f), Time.deltaTime * speed1);

                    round.color = Color.Lerp(round.color, new Color(240 / 255.0f, 240 / 255.0f, 120 / 255.0f), Time.deltaTime * speed1);
                    roundObject.transform.localScale = Vector3.Lerp(roundObject.transform.localScale, originalScale2 * roundRadiusRatio, Time.deltaTime * speed1);
                    round.transform.Rotate(0, 0, -1 * speed2 * Time.deltaTime);
                }
                else //再次按下时的特效
                {

                    transform.localScale = Vector3.Lerp(transform.localScale, originalScale1 * scaleRatio1, Time.deltaTime * speed1);
                    round.transform.localScale = Vector3.Lerp(round.transform.localScale, originalScale2, Time.deltaTime * speed1);
                    round.transform.Rotate(0, 0, -1 * speed2 * Time.deltaTime * 3);
                }
            }

        }
        else
        {
            whiteCircle.color = Color.Lerp(whiteCircle.color, originalColor1 * drakPercentage, Time.deltaTime * speed1);
        }
    }
    IEnumerator endEffect()
    {
        while (true)
        {
            end = !isPressed && lastTime < maxLastTime;
            if (!end)
            {
                transform.localPosition = originalScale1;
                whiteCircle.color = originalColor1;

                round.transform.localPosition = originalScale2;
                round.color = new Color(1, 1, 1, 0);

                cup.transform.localScale = Vector3.one;
                cup.color = Color.white;
                break;
            }
            lastTime += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale1, Time.deltaTime * speed1);
            whiteCircle.color = Color.Lerp(whiteCircle.color, originalColor1, Time.deltaTime * speed1);

            round.transform.localScale = Vector3.Lerp(round.transform.localScale, originalScale2 * roundRadiusRatio * 1.5f, Time.deltaTime * speed1 / 3);
            round.transform.Rotate(0, 0, -1 * speed2 * Time.deltaTime);
            round.color = Color.Lerp(round.color, new(1, 1, 1, 0), Time.deltaTime * speed1 / 3);

            cup.transform.localScale = Vector3.Lerp(cup.transform.localScale, originalScale2 * roundRadiusRatio * 1.8f, Time.deltaTime * speed1 / 3);
            cup.color = Color.Lerp(cup.color, new(1, 1, 1, 0), Time.deltaTime * speed1 / 3);
            yield return null;
        }
    }
}

