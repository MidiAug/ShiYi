using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class EditorText : Editor
{
    //设置全是单独的Text是可以的,一旦来个Button里面的text改了有问题
    [MenuItem("Tools/调整全是Text清晰度")]
    public static void UpdateText()
    {
        //寻找Hierarchy面板下所有的Text
        var tArray = Resources.FindObjectsOfTypeAll(typeof(Text));
        for (int i = 0; i < tArray.Length; i++)
        {
            Text t = tArray[i] as Text;
            //记录对象
            Undo.RecordObject(t, t.gameObject.name);
            t.fontSize = t.fontSize * 2;

            t.GetComponent<RectTransform>().sizeDelta = new Vector2(t.GetComponent<RectTransform>().rect.width * 2, t.GetComponent<RectTransform>().rect.height * 2);
            t.GetComponent<RectTransform>().localScale = new Vector3(t.GetComponent<RectTransform>().localScale.x / 2, t.GetComponent<RectTransform>().localScale.y / 2, t.GetComponent<RectTransform>().localScale.z / 2);

            //设置已改变
            EditorUtility.SetDirty(t);
        }
        Debug.Log("完成");
    }
    //设置有单独的Text还有父物体是button的Text
    [MenuItem("Tools/调整Text加Button清晰度")]
    public static void UpdateText_Btn()
    {
        //寻找Hierarchy面板下所有的Text
        var tArray = Resources.FindObjectsOfTypeAll(typeof(Text));
        for (int i = 0; i < tArray.Length; i++)
        {
            Text t = tArray[i] as Text;
            //记录对象
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

            //设置已改变
            EditorUtility.SetDirty(t);
        }
        Debug.Log("完成");
    }
}

