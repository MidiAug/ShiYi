using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickGoBack : MonoBehaviour
{
    public void StartGame()
    {
        //通过scene-3的方式实现场景切换
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 3);
    }
}
