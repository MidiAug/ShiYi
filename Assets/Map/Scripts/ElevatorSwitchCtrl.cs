using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ElevatorSwitchCtrl : MonoBehaviour
{
    public ElevatorCtrl elevatorCtrl;
    private Vector3 originalPosition; // ԭʼλ��
    private Vector3 pressedPosition; // ���º��λ��
    //public bool isFollowElevator = false;  // �Ƿ񿪹ظ������һͬ�ƶ�

  void Start()
    {
        float buttonHeight = GetComponent<SpriteRenderer>().bounds.size.y; // ��ȡ��ť�ĸ߶�
        float moveDistance = buttonHeight * 0.9f; // ���㰴ť�����ƶ��ľ���
        pressedPosition = transform.position + Vector3.down * moveDistance; // ���º��λ��
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Playercontroller pc = other.GetComponent<Playercontroller>();
        if (pc != null)
        {
            if (elevatorCtrl != null)
            {
                elevatorCtrl.setIsMove(true); // �����˶�
            }
            MoveButton(); // �ƶ���ť
        }
        GetComponent<Collider2D>().enabled = false; // ���ð�ť����ײ��
    }

    private void MoveButton()
    {
        transform.position = pressedPosition; // ����ť�ƶ������º��λ��
    }
    
    
    //public void FollowElevator(Vector3 initialSwitchOffset,Vector3 ElevatorPosition)
    //{
    //  if (isFollowElevator){
    //    // ʹ��localPosition�������λ��
    //    transform.localPosition = ElevatorPosition + initialSwitchOffset;
    //  }
    //}
}
