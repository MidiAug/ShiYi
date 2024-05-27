using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public GameObject player;
    //private Playercontroller playercontroller;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI What;
    void Update()
    {
        Score.SetText(player.gameObject.GetComponent<Playercontroller>().Score.ToString());
        if (player.gameObject.GetComponent<Playercontroller>().Notice =='b')
        {
            What.SetText("你从 箱子 中获得了 " + "万印茶恢复 ×1");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        else if(player.gameObject.GetComponent<Playercontroller>().Notice == 'f')
        {
            What.SetText("你从 箱子 中获得了 " + "竹藤编恢复 ×1");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        else if(player.gameObject.GetComponent<Playercontroller>().Notice == 'o')
        {
            What.SetText("你从 箱子 中获得了 " + "积分 ×1");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        else if (player.gameObject.GetComponent<Playercontroller>().Notice == 't')
        {
            What.SetText("你从 箱子 中获得了 "+ "积分 ×2" );
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        else if (player.gameObject.GetComponent<Playercontroller>().Notice == 'F')
        {
            What.SetText("你从 箱子 中获得了 " + "积分 ×5");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        else if (player.gameObject.GetComponent<Playercontroller>().Notice == 'W')
        {
            What.SetText("你从 箱子 中获得了 " + "五祖拳秘籍");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        else if (player.gameObject.GetComponent<Playercontroller>().Notice == 'H')
        {
            What.SetText("你从 箱子 中获得了 " + "永春纸织画");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        //gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
    void Open()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        // 启动协程
        StartCoroutine(DeactivateChildWithDelay(3.0f));
    }
    IEnumerator DeactivateChildWithDelay(float delay)
    {
        // 等待指定的秒数
        yield return new WaitForSeconds(delay);
        // 获取第一个子对象并设置为不激活状态
        if (transform.childCount > 1)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
