using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public GameObject escMenu;
    // Start is called before the first frame update
    void Start()
    {
        escMenu.SetActive(false);
    }

    //按下esc键时，暂停游戏，并且显示菜单
   
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escMenu.activeSelf)
            {
                escMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                escMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void ContinueGame()
    {
        escMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
