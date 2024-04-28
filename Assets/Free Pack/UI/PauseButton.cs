using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject gameObject;
    //当按键检测到按下时，暂停游戏并打开菜单
    public void Pausethegame()
    {
        
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
