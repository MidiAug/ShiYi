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
            rand = Random.Range(1, 10);
            if(rand==1)
            {
                player.gameObject.GetComponent<Playercontroller>().backtimes = 9;
                Skill.gameObject.GetComponent<SkillController>().SkillOneTimes = 9;
                Skill.gameObject.GetComponent<SkillController>().RefreshUI();
                Destroy(gameObject);
            }
            else if(rand==2)
            {
                player.gameObject.GetComponent<Playercontroller>().dashTimes = 8;
                Skill.gameObject.GetComponent<SkillController>().SkillTwoTimes = 8;
                Skill.gameObject.GetComponent<SkillController>().RefreshUI();
                Destroy(gameObject);
            }
            else if(rand==3|| rand == 4|| rand == 5|| rand == 6)//积分加1
            {
                player.gameObject.GetComponent<Playercontroller>().Score += 1;
                Destroy(gameObject);
            }
            else if(rand==7|| rand == 8)//积分加2
            {
                player.gameObject.GetComponent<Playercontroller>().Score += 2;
                Destroy(gameObject);
            }
            else if(rand==9)//积分加5
            {
                player.gameObject.GetComponent<Playercontroller>().Score += 5;
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
