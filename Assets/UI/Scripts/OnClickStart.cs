using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickStart : MonoBehaviour
{
    public void StartGame()
    {
        //ͨ��scene+1�ķ�ʽʵ�ֳ����л�
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
