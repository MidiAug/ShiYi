using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickContinue : MonoBehaviour
{
   //按下该按键时，继续游戏并关闭菜单
   GameObject gameObject;
    void Start()
    {
        gameObject = GameObject.Find("EscMenu");
    }
   public void ContinueGame()
    {
        gameObject = GameObject.Find("EscMenu");
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
