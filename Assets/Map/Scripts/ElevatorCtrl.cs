using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ElevatorCtrl : MonoBehaviour
{

    // 这个平台会在board和end的位置间来回移动，一般情况下两种Pos.x相同
    // 将switch合并一起方便管理
    public enum MoveDir { GO, BACK } // 物体在两点间的方向

    public bool isMove = false; // 
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
        if (isMove)
        {
            deltaTime += Time.deltaTime;
            float t = (Mathf.Sin((deltaTime) * speed - Mathf.PI / 2) + 1f) / 2f;
            board.transform.position = Vector3.Lerp(startPos, endPos, t);
        }

    }
    public void setIsMove(bool isMove)
    {
        this.isMove = isMove;
    }
}