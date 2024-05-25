using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpecialEffect : MonoBehaviour
{
    // �԰�ɫԲ�εĿ���
    public float drakPercentage = 0.3f; //�䰵�İٷֱ�
    public float scaleRatio1 = 0.7f; // ���δ�С
    public float speed1 = 5f;
    private Image whiteCircle;
    private Vector3 originalScale1;
    private Color originalColor1;

    // ��Χ��ȦȦ,��ת,��ɫ����С���ϱ�
    public GameObject roundObject;
    private Image round;
    public float roundRadiusRatio;
    public float speed2;
    private Vector3 originalScale2;
    private Color originalColor2;

    // ��Χ�Ĳ豭
    public GameObject cupObject;
    private Image cup;


    private bool isBan = false;    // ������ʹ��
    private bool isUsing = false; // ʹ�ü����У��ͷź�Ӱ��
    private bool isPressed = false; // �Ƿ��¼�λ
    private bool release = false; // �ͷż���
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


        if (!isBan) // ���ܿ���ʹ��
        {
            if (!isUsing) // δ�����ͷź�Ӱ��״̬
            {

                if (isPressed) // ���¼��ܼ�
                {
                    whiteCircle.color = Color.Lerp(whiteCircle.color, originalColor1 * drakPercentage, Time.deltaTime * speed1);
                    transform.localScale = Vector3.Lerp(transform.localScale, originalScale1 * scaleRatio1, Time.deltaTime * speed1);

                    round.transform.localScale = Vector3.Lerp(round.transform.localScale, originalScale2, Time.deltaTime * speed1 * 3);
                    round.color = Color.Lerp(round.color, Color.white, Time.deltaTime * speed1 * 2);
                }
                else
                {
                    if (release) // �ع��Ӱλ��
                    {
                        lastTime = 0f;
                        StartCoroutine(endEffect());
                        release = false;
                    }
                }
            }

            else // �ͷź�Ӱ��״̬
            {
                if (!isPressed) //��Ӱ״̬�µļ�����ʽ
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, originalScale1, Time.deltaTime * speed1);
                    whiteCircle.color = Color.Lerp(whiteCircle.color, new Color(240 / 255.0f, 240 / 255.0f, 210 / 255.0f), Time.deltaTime * speed1);
                    cup.color = Color.Lerp(cup.color, new Color(240 / 255.0f, 240 / 255.0f, 210 / 255.0f), Time.deltaTime * speed1);

                    round.color = Color.Lerp(round.color, new Color(240 / 255.0f, 240 / 255.0f, 120 / 255.0f), Time.deltaTime * speed1);
                    roundObject.transform.localScale = Vector3.Lerp(roundObject.transform.localScale, originalScale2 * roundRadiusRatio, Time.deltaTime * speed1);
                    round.transform.Rotate(0, 0, -1 * speed2 * Time.deltaTime);
                }
                else //�ٴΰ���ʱ����Ч
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

