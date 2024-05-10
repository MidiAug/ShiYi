using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorCtrl : MonoBehaviour
{

    // 这个平台会在board和end的位置间来回移动，一般情况下两种Pos.x相同
    // 将switch合并一起方便管理
    public enum MoveDir { GO, BACK } // 物体在两点间的方向

    public bool isMove = false; 
    public bool isBackAndForth=false;
   
    public float chargeTime = 1f;    // 达到最大速度所需时间
    public float desireTime = 1.5f;  // 期望到达目标地点的时间
    public float speed;

    public GameObject board;
    public GameObject endObj;
    private Vector3 startPos;
    private Vector3 endPos;
    private MoveDir moveDir;

    private float deltaTime = 0;

    void Start()
    {
        startPos = board.transform.position;
        endPos = endObj.transform.position;
    }
    void Update()
    {
        // 如果不来回运动且电梯已到终点，停止运动
        if (board.transform.position == endPos && !isBackAndForth)
          isMove = false;
        if (isMove&&isBackAndForth)
        {
            deltaTime += Time.deltaTime;
            float t = (Mathf.Sin((deltaTime) * speed - Mathf.PI / 2) + 1f) / 2f * Mathf.Min(deltaTime / chargeTime, 1);
            board.transform.position = Vector3.Lerp(startPos, endPos, t);
        }
        else if (isMove&&!isBackAndForth) {
            deltaTime += Time.deltaTime;
            // 计算从起点到终点的总距离
            float totalDistance = Vector3.Distance(startPos, endPos);
            speed = totalDistance / desireTime * Mathf.Min(deltaTime / chargeTime,1);
            float t = Mathf.Min(deltaTime * speed / totalDistance, 1f);
            // 根据 t 设置位置
            board.transform.position = Vector3.Lerp(startPos, endPos, t);
        }

    }
    public void setIsMove(bool isMove)
    {
        this.isMove = isMove;
    }
}