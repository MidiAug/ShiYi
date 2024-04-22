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

    public float moveSpeed; // 移动速度
    public bool isMove = true; // 是否进行移动
    public Transform startTrans; // 开始的点
    public Transform endTrans; // 结束的点
    public GameObject trapObj; // 陷阱物体（注意修改为 GameObject 类型）
    public TrapMoveDir moveDir; // 移动方向枚举

    void Update()
    {
        TrapMoveLogic(); // 调用移动逻辑
    }

    void TrapMoveLogic()
    {
        if (!isMove)
            return;

        if (moveDir == TrapMoveDir.Down)
        {
            trapObj.transform.position += Vector3.down * moveSpeed * Time.deltaTime; // 朝下移动
            float distance = Vector3.Distance(trapObj.transform.position, startTrans.position);
            if (distance < 0.5f) // 如果现在距离最下面的点小于0.5f，重新设置移动方向
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
