using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ElevatorCtrl : MonoBehaviour
{
    public enum MoveDir { GO,BACK } // 去end还是start

    public bool isMove = true; // 是否进行移动
    public float speed; // 移动速度

    //public GameObject startObj; startObj直接为自身
    public GameObject endObj;
    private Vector3 startPos;
    private Vector3 endPos;
    private MoveDir moveDir; // 移动方向枚举
    private float startTime;        // 记录运动开始的时间

    public GameObject board; 
    void Start()
    {
        startPos = board.transform.position;
        endPos = endObj.transform.position;
        startTime = Time.time;     // 记录运动开始的时间
    }
    void Update()
    {
        //TrapMoveLogic(); // 调用移动逻辑
        float t = (Mathf.Sin((Time.time - startTime) * speed) + 1f) / 2f;

        // 使用插值计算当前位置
        board.transform.position = Vector3.Lerp(startPos, endPos, t);
    }

/*    void TrapMoveLogic()
    {
        if (!isMove)
            return;


        if (moveDir == MoveDir.GO)
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime; // 朝下移动
            float distance = Vector3.Distance(transform.position, startTrans.position);
            if (distance < 0.5f) // 如果现在距离最下面的点小于0.5f，重新设置移动方向
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
