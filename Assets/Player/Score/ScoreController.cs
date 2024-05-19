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
            What.SetText("You get the " + "BackRefresh ��1"+ " from the box");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        else if(player.gameObject.GetComponent<Playercontroller>().Notice == 'f')
        {
            What.SetText("You get the " + "FlashRefresh ��1" + " from the box");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        else if(player.gameObject.GetComponent<Playercontroller>().Notice == 'o')
        {
            What.SetText("You get the " + "Score ��1" + " from the box");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        else if (player.gameObject.GetComponent<Playercontroller>().Notice == 't')
        {
            What.SetText("You get the " + "Score ��2" + " from the box");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        else if (player.gameObject.GetComponent<Playercontroller>().Notice == 'F')
        {
            What.SetText("You get the " + "Score ��5" + " from the box");
            player.gameObject.GetComponent<Playercontroller>().Notice = 'q';
            Open();
        }
        //gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
    void Open()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        // ����Э��
        StartCoroutine(DeactivateChildWithDelay(3.0f));
    }
    IEnumerator DeactivateChildWithDelay(float delay)
    {
        // �ȴ�ָ��������
        yield return new WaitForSeconds(delay);
        // ��ȡ��һ���Ӷ�������Ϊ������״̬
        if (transform.childCount > 1)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
