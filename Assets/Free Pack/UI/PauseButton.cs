using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject gameObject;
    //��������⵽����ʱ����ͣ��Ϸ���򿪲˵�
    public void Pausethegame()
    {
        
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
