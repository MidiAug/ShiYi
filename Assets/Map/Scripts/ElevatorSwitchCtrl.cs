using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ElevatorSwitchCtrl : MonoBehaviour
{
    public ElevatorCtrl elevatorCtrl;
    public bool isFollowElevator=false;
    private Vector3 originalPosition; // ԭʼλ��
    private Vector3 pressedPosition; // ���º��λ��
    public Sprite switch2;
    private SpriteRenderer spriteRenderer;

  void Start()
    {
        float buttonHeight = GetComponent<SpriteRenderer>().bounds.size.y; // ��ȡ��ť�ĸ߶�
        float moveDistance = buttonHeight * 0.9f; // ���㰴ť�����ƶ��ľ���
        pressedPosition = transform.position + Vector3.down * moveDistance; // ���º��λ��
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            if (!isFollowElevator)
                //MoveButton(); // �ƶ���ť
                changeSprite();
        }
        GetComponent<Collider2D>().enabled = false; // ���ð�ť����ײ��
    }
    
    private void MoveButton()
    {
        transform.position = pressedPosition; // ����ť�ƶ������º��λ��
    }
    //�����µ���ͼ
    private void changeSprite()
    {
        spriteRenderer.sprite = switch2;
    }
}
