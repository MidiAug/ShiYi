using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ElevatorCtrl : MonoBehaviour
{
    public enum MoveDir { GO,BACK } // ȥend����start

    public bool isMove = true; // �Ƿ�����ƶ�
    public float speed; // �ƶ��ٶ�

    //public GameObject startObj; startObjֱ��Ϊ����
    public GameObject endObj;
    private Vector3 startPos;
    private Vector3 endPos;
    private MoveDir moveDir; // �ƶ�����ö��
    private float startTime;        // ��¼�˶���ʼ��ʱ��

    public GameObject board; 
    void Start()
    {
        startPos = board.transform.position;
        endPos = endObj.transform.position;
        startTime = Time.time;     // ��¼�˶���ʼ��ʱ��
    }
    void Update()
    {
        //TrapMoveLogic(); // �����ƶ��߼�
        float t = (Mathf.Sin((Time.time - startTime) * speed) + 1f) / 2f;

        // ʹ�ò�ֵ���㵱ǰλ��
        board.transform.position = Vector3.Lerp(startPos, endPos, t);
    }

/*    void TrapMoveLogic()
    {
        if (!isMove)
            return;


        if (moveDir == MoveDir.GO)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime; // �����ƶ�
            float distance = Vector3.Distance(transform.position, startTrans.position);
            if (distance < 0.5f) // ������ھ���������ĵ�С��0.5f�����������ƶ�����
            {
                moveDir = MoveDir.UP;
            }
            Debug.Log(distance);
        }
        else if (moveDir == MoveDir.BACK)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y - firstPos.y > upDis)
            {
                moveDir = MoveDir.Down;
            }

            if (distance < 0.5f)
            {
                moveDir = MoveDir.Down;
            }
        }
    }
*/}
