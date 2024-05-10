using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ElevatorSwitchCtrl : MonoBehaviour
{
    public ElevatorCtrl elevatorCtrl;
    private Vector3 originalPosition; // 原始位置
    private Vector3 pressedPosition; // 按下后的位置
    //public bool isFollowElevator = false;  // 是否开关跟随电梯一同移动

  void Start()
    {
        float buttonHeight = GetComponent<SpriteRenderer>().bounds.size.y; // 获取按钮的高度
        float moveDistance = buttonHeight * 0.9f; // 计算按钮向下移动的距离
        pressedPosition = transform.position + Vector3.down * moveDistance; // 按下后的位置
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Playercontroller pc = other.GetComponent<Playercontroller>();
        if (pc != null)
        {
            if (elevatorCtrl != null)
            {
                elevatorCtrl.setIsMove(true); // 启动运动
            }
            MoveButton(); // 移动按钮
        }
        GetComponent<Collider2D>().enabled = false; // 禁用按钮的碰撞器
    }

    private void MoveButton()
    {
        transform.position = pressedPosition; // 将按钮移动到按下后的位置
    }
    
    
    //public void FollowElevator(Vector3 initialSwitchOffset,Vector3 ElevatorPosition)
    //{
    //  if (isFollowElevator){
    //    // 使用localPosition保持相对位置
    //    transform.localPosition = ElevatorPosition + initialSwitchOffset;
    //  }
    //}
}
