using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGoBack : MonoBehaviour
{
    public void StartGame()
    {
        //ͨ��scene-3�ķ�ʽʵ�ֳ����л�
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 3);
    }
}
