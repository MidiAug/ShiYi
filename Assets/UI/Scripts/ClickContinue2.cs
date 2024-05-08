using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickContinue2 : MonoBehaviour
{
    //按下该按键时，继续游戏并关闭菜单
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
