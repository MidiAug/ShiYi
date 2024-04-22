using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapMove : MonoBehaviour
{
    public enum TrapMoveDir
    {
        None,
        Down,
        Up,
    }

    public float moveSpeed; // �ƶ��ٶ�
    public bool isMove = true; // �Ƿ�����ƶ�
    public Transform startTrans; // ��ʼ�ĵ�
    public Transform endTrans; // �����ĵ�
    public GameObject trapObj; // �������壨ע���޸�Ϊ GameObject ���ͣ�
    public TrapMoveDir moveDir; // �ƶ�����ö��

    void Update()
    {
        TrapMoveLogic(); // �����ƶ��߼�
    }

    void TrapMoveLogic()
    {
        if (!isMove)
            return;

        if (moveDir == TrapMoveDir.Down)
        {
            trapObj.transform.position += Vector3.down * moveSpeed * Time.deltaTime; // �����ƶ�
            float distance = Vector3.Distance(trapObj.transform.position, startTrans.position);
            if (distance < 0.5f) // ������ھ���������ĵ�С��0.5f�����������ƶ�����
            {
                moveDir = TrapMoveDir.Up;
            }
        }
        else if (moveDir == TrapMoveDir.Up)
        {
            trapObj.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            float distance = Vector3.Distance(trapObj.transform.position, endTrans.position);
            if (distance < 0.5f)
            {
                moveDir = TrapMoveDir.Down;
            }
        }
    }
}
