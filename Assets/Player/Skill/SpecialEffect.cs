using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpecialEffect : MonoBehaviour
{
    // ���Ʊ���ļ�������
    public float darkenPercentage = 0.5f; // ����İٷֱ�
    public float scaleRatio = 0.9f; // ��С�ı���
    public float transitionSpeed = 5f; // �����ٶ�
    private Image buttonImage;
    private Vector3 originalScale;
    private bool isPressed = false;
    private Color originalColor;

    //������Χ��Ч�Ĳ���
    public Image image;
    public float scaleRatio2 = 0.9f; // �Ŵ�ı���
    public float transitionSpeed2 = 5f; // �����ٶ�
    public bool release = false;
    private Color originalColor2;
    private Vector3 originalScale2;



    private bool ban = false;


    void Start()
    {
        buttonImage = GetComponent<Image>(); // ��ȡ��ť��Image���
        originalScale = transform.localScale; // ��¼��ť��ԭʼ���ű���
        originalColor = buttonImage.color; // ��¼��ť��ԭʼ��ɫ

        originalScale2 = image.transform.localScale; // ��¼��Ч��ԭʼ���ű���
        originalColor2 = image.color; // ��¼��Ч��ԭʼ��ɫ

        image.gameObject.SetActive(false);
    }

    void Update()
    {
        // ��Ч�����ж�
        if(image.color.a < 0.5f)
        {
            release = false;
        }

        // ��ס���� L ʱ����Ч��
        if (Input.GetKeyDown(KeyCode.L))
        {
            isPressed = true;
        }

        // �ɿ����� L ʱ�ָ�ԭ״
        if (Input.GetKeyUp(KeyCode.L))
        {
            isPressed = false;
            release = true;
        }

        if (!ban)
        {
            // ���ݰ���״̬�𽥱仯Ч��
            if (isPressed)
            {
                // �ı䰴ť����ɫΪ��������ɫ
                buttonImage.color = Color.Lerp(buttonImage.color, originalColor * (1 - darkenPercentage), Time.deltaTime * transitionSpeed);
                // ��С��ť�Ĵ�С
                transform.localScale = Vector3.Lerp(transform.localScale, originalScale * scaleRatio, Time.deltaTime * transitionSpeed);
            }
            else
            {
                // �ָ���ť��ԭʼ��ɫ
                buttonImage.color = Color.Lerp(buttonImage.color, originalColor, Time.deltaTime * transitionSpeed);
                // �ָ���ť��ԭʼ��С
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
                // �ָ���ʼ״̬
                image.gameObject.SetActive(false);
                image.color = originalColor2;
                image.transform.localScale = originalScale2;
            }
        }

        else
        {
            buttonImage.color = Color.Lerp(buttonImage.color, originalColor * (1 - darkenPercentage), Time.deltaTime * transitionSpeed);
            // �ָ���ʼ״̬
            image.gameObject.SetActive(false);
            image.color = originalColor2;
            image.transform.localScale = originalScale2;
        }
    }
    public void banTheSkill() { ban = true; }

}

