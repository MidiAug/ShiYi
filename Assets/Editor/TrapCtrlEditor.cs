using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TrapCtrl))]
public class trapCtrlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TrapCtrl trapCtrl = (TrapCtrl)target;

        // 显示 TrapMode 的下拉菜单
        trapCtrl.trapMode = (TrapCtrl.TrapMode)EditorGUILayout.EnumPopup("Trap Mode", trapCtrl.trapMode);

        // 根据选择的模式显示对应的变量
        switch (trapCtrl.trapMode)
        {
            case TrapCtrl.TrapMode.Drop:
                trapCtrl.dropTrigglePos = (GameObject)EditorGUILayout.ObjectField("dropTrigglePos", trapCtrl.dropTrigglePos, typeof(GameObject), true);
                trapCtrl.gravityScale = EditorGUILayout.FloatField("gravityScale", trapCtrl.gravityScale);
                trapCtrl.dropTriggleRadius = EditorGUILayout.FloatField("dropTriggleRadius", trapCtrl.dropTriggleRadius);
                break;
            case TrapCtrl.TrapMode.PopUp:
                trapCtrl.upTime = EditorGUILayout.FloatField("upTime", trapCtrl.upTime);
                trapCtrl.downTime = EditorGUILayout.FloatField("downTime", trapCtrl.downTime);
                break;
            default:
                break;
        }

        // 应用修改
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
