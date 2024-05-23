using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class EditorText : Editor
{
    //����ȫ�ǵ�����Text�ǿ��Ե�,һ������Button�����text����������
    [MenuItem("Tools/����ȫ��Text������")]
    public static void UpdateText()
    {
        //Ѱ��Hierarchy��������е�Text
        var tArray = Resources.FindObjectsOfTypeAll(typeof(Text));
        for (int i = 0; i < tArray.Length; i++)
        {
            Text t = tArray[i] as Text;
            //��¼����
            Undo.RecordObject(t, t.gameObject.name);
            t.fontSize = t.fontSize * 2;

            t.GetComponent<RectTransform>().sizeDelta = new Vector2(t.GetComponent<RectTransform>().rect.width * 2, t.GetComponent<RectTransform>().rect.height * 2);
            t.GetComponent<RectTransform>().localScale = new Vector3(t.GetComponent<RectTransform>().localScale.x / 2, t.GetComponent<RectTransform>().localScale.y / 2, t.GetComponent<RectTransform>().localScale.z / 2);

            //�����Ѹı�
            EditorUtility.SetDirty(t);
        }
        Debug.Log("���");
    }
    //�����е�����Text���и�������button��Text
    [MenuItem("Tools/����Text��Button������")]
    public static void UpdateText_Btn()
    {
        //Ѱ��Hierarchy��������е�Text
        var tArray = Resources.FindObjectsOfTypeAll(typeof(Text));
        for (int i = 0; i < tArray.Length; i++)
        {
            Text t = tArray[i] as Text;
            //��¼����
            Undo.RecordObject(t, t.gameObject.name);
            t.fontSize = t.fontSize * 2;
            if (t.transform.parent.GetComponent<Button>())
            {
                float xx = t.transform.parent.GetComponent<RectTransform>().rect.width;
                float yy = t.transform.parent.GetComponent<RectTransform>().rect.height;

                t.GetComponent<RectTransform>().localScale = new Vector3(t.GetComponent<RectTransform>().localScale.x / 2, t.GetComponent<RectTransform>().localScale.y / 2, t.GetComponent<RectTransform>().localScale.z / 2);
                t.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
                t.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                t.GetComponent<RectTransform>().sizeDelta = new Vector2(xx * (1 / t.GetComponent<RectTransform>().localScale.x), yy *
                    (1 / t.GetComponent<RectTransform>().localScale.x));
                t.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                Debug.Log(xx);
            }
            else
            {
                t.GetComponent<RectTransform>().sizeDelta = new Vector2(t.GetComponent<RectTransform>().rect.width * 2, t.GetComponent<RectTransform>().rect.height * 2);
                t.GetComponent<RectTransform>().localScale = new Vector3(t.GetComponent<RectTransform>().localScale.x / 2, t.GetComponent<RectTransform>().localScale.y / 2, t.GetComponent<RectTransform>().localScale.z / 2);
            }

            //�����Ѹı�
            EditorUtility.SetDirty(t);
        }
        Debug.Log("���");
    }
}

