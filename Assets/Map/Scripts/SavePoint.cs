using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
  // �浵����������
  public float triggerDistance = 3.0f;  // �����浵�ľ���

  // ���
  private GameObject playerObject;  // ��Ҷ���
  private Playercontroller player;

  void Start()
  {
    // �ҵ���Ҷ��󣬼�����Ҷ���ı�ǩ��"Player"
    playerObject = GameObject.FindGameObjectWithTag("Player");
    player = playerObject.GetComponent<Playercontroller>();
  }

  void Update()
  {
    // �������Ƿ��ڴ浵��Ĵ���������
    if (Vector3.Distance(playerObject.transform.position, transform.position) <= triggerDistance)
    {
      // �������Ƿ��� 'E' ��
      if (Input.GetKeyDown(KeyCode.E))
      {
        SaveGame();
      }
    }
  }

  void SaveGame()
  {
    // ����ʵ�ִ浵�߼������籣�����λ��
    Vector3 playerPosition = player.transform.position;
    Debug.Log("Game saved at position: " + playerPosition);
    player.UpdateRespawnPos(playerPosition);
  }


}
