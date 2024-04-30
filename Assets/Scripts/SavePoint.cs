using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
  // 存档点的相关属性
  public float triggerDistance = 3.0f;  // 触发存档的距离

  // 组件
  private GameObject playerObject;  // 玩家对象
  private Playercontroller player;

  void Start()
  {
    // 找到玩家对象，假设玩家对象的标签是"Player"
    playerObject = GameObject.FindGameObjectWithTag("Player");
    player = playerObject.GetComponent<Playercontroller>();
  }

  void Update()
  {
    // 检查玩家是否在存档点的触发距离内
    if (Vector3.Distance(playerObject.transform.position, transform.position) <= triggerDistance)
    {
      // 检查玩家是否按下 'E' 键
      if (Input.GetKeyDown(KeyCode.E))
      {
        SaveGame();
      }
    }
  }

  void SaveGame()
  {
    // 这里实现存档逻辑，例如保存玩家位置
    Vector3 playerPosition = player.transform.position;
    Debug.Log("Game saved at position: " + playerPosition);
    player.UpdateRespawnPos(playerPosition);
  }


}
