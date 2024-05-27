using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RBoxcontroller : MonoBehaviour
{
    private bool isTrigger = false;
    public GameObject player;
    private int rand = 0;
    public GameObject Skill;
    private void Update()
    {
        if(isTrigger==true&&Input.GetKeyDown(KeyCode.B))
        {
            rand = Random.Range(1, 12);
            if(rand==1)
            {
                player.gameObject.GetComponent<Playercontroller>().backtimes = 9;
                player.gameObject.GetComponent<Playercontroller>().Notice = 'b';
                Skill.gameObject.GetComponent<SkillController>().SkillOneTimes = 9;
                Skill.gameObject.GetComponent<SkillController>().RefreshUI();
                Destroy(gameObject);
            }
            else if(rand==2)
            {
                player.gameObject.GetComponent<Playercontroller>().dashTimes = 8;
                player.gameObject.GetComponent<Playercontroller>().Notice = 'f';
                Skill.gameObject.GetComponent<SkillController>().SkillTwoTimes = 8;
                Skill.gameObject.GetComponent<SkillController>().RefreshUI();
                Destroy(gameObject);
            }
            else if(rand==3|| rand == 4|| rand == 5|| rand == 6)//���ּ�1
            {
                player.gameObject.GetComponent<Playercontroller>().Score += 1;
                player.gameObject.GetComponent<Playercontroller>().Notice = 'o';
                Destroy(gameObject);
            }
            else if(rand==7|| rand == 8)//���ּ�2
            {
                player.gameObject.GetComponent<Playercontroller>().Score += 2;
                player.gameObject.GetComponent<Playercontroller>().Notice = 't';
                Destroy(gameObject);
            }
            else if(rand==9)//���ּ�5
            {
                player.gameObject.GetComponent<Playercontroller>().Score += 5;
                player.gameObject.GetComponent<Playercontroller>().Notice = 'F';
                Destroy(gameObject);
            }
            else if (rand == 10)//����ȭ
            {
                player.gameObject.GetComponent<Playercontroller>().HaveDraw = true;
                player.gameObject.GetComponent<Playercontroller>().Notice = 'W';
                Destroy(gameObject);
            }
            else if (rand == 11)//��
            {
                player.gameObject.GetComponent<Playercontroller>().HaveFist = true;
                player.gameObject.GetComponent<Playercontroller>().Notice = 'H';
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;
    }
}
