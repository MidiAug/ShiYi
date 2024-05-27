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
  public Sprite newSprite;  // 新的精灵图像引用

  private void Update()
  {
    if (isTrigger == true && Input.GetKeyDown(KeyCode.B))
    {
      rand = Random.Range(1, 12);
      //if (rand == 1)
      //{
      //  player.gameObject.GetComponent<Playercontroller>().backtimes = 9;
      //  player.gameObject.GetComponent<Playercontroller>().Notice = 'b';
      //  Skill.gameObject.GetComponent<SkillController>().SkillOneTimes = 9;
      //  Skill.gameObject.GetComponent<SkillController>().RefreshUI();
      //  ChangeSprite();
      //}
      //else if (rand == 2)
      //{
      //  player.gameObject.GetComponent<Playercontroller>().dashTimes = 8;
      //  player.gameObject.GetComponent<Playercontroller>().Notice = 'f';
      //  Skill.gameObject.GetComponent<SkillController>().SkillTwoTimes = 8;
      //  Skill.gameObject.GetComponent<SkillController>().RefreshUI();
      //  ChangeSprite();
      //}
      //else if (rand == 3) // 积分加1
      //{
      //  player.gameObject.GetComponent<Playercontroller>().Score += 1;
      //  player.gameObject.GetComponent<Playercontroller>().Notice = 'o';
      //  ChangeSprite();
      //}
      //else if (rand == 7 || rand == 8) // 积分加2
      //{
      //  player.gameObject.GetComponent<Playercontroller>().Score += 2;
      //  player.gameObject.GetComponent<Playercontroller>().Notice = 't';
      //  ChangeSprite();
      //}
      //else if (rand == 9) // 积分加5
      //{
      //  player.gameObject.GetComponent<Playercontroller>().Score += 5;
      //  player.gameObject.GetComponent<Playercontroller>().Notice = 'F';
      //  ChangeSprite();
      //}
      //else if (rand=11) // 五祖拳
      //{
      //  player.gameObject.GetComponent<Playercontroller>().HaveDraw = true;
      //  player.gameObject.GetComponent<Playercontroller>().Notice = 'H';
      //ChangeSprite();
      //}
      //else if (rand == 10 || rand == 4 || rand == 5 || rand == 6) // 画
      //{
        player.gameObject.GetComponent<Playercontroller>().HaveFist = true;
        player.gameObject.GetComponent<Playercontroller>().Notice = 'W';
        ChangeSprite();
      //}
    }
  }

  private void ChangeSprite()
  {
    GetComponent<SpriteRenderer>().sprite = newSprite;
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      isTrigger = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    isTrigger = false;
  }
}
