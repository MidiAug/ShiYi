using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickContinue2 : MonoBehaviour
{
    //���¸ð���ʱ��������Ϸ���رղ˵�
    GameObject gameObject;
    void Start()
    {
        gameObject = GameObject.Find("MusicSetting");
    }
    public void ContinueGame()
    {
        gameObject = GameObject.Find("MusicSetting");
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
