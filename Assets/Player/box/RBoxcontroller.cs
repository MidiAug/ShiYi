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
            rand = Random.Range(1, 3);
            if(rand==1)
            {
                player.gameObject.GetComponent<Playercontroller>().backtimes = 9;
                Skill.gameObject.GetComponent<SkillController>().SkillOneTimes = 9;
                Skill.gameObject.GetComponent<SkillController>().RefreshUI();
            }
            else
            {
                player.gameObject.GetComponent<Playercontroller>().dashTimes = 8;
                Skill.gameObject.GetComponent<SkillController>().SkillTwoTimes = 8;
                Skill.gameObject.GetComponent<SkillController>().RefreshUI();
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
