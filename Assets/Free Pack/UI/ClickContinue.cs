using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickContinue : MonoBehaviour
{
   //���¸ð���ʱ��������Ϸ���رղ˵�
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
