//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ElevatorSystemCtrl : MonoBehaviour
//{
//  public ElevatorSwitchCtrl elevatorSwitch; // 设置为公有，方便在Inspector中赋值
//  public ElevatorCtrl elevator; // 设置为公有，方便在Inspector中赋值
//  private Vector3 initialSwitchOffset; // 开关相对于电梯的初始偏移

//  private void Start()
//  {
//    Debug.Log(initialSwitchOffset);
//    // 确保从子对象中获取组件
//    if (elevator == null)
//    {
//      elevator = GetComponentInChildren<ElevatorCtrl>();
//    }

//    if (elevatorSwitch == null)
//    {
//      elevatorSwitch = GetComponentInChildren<ElevatorSwitchCtrl>();
//    }

//    // 检查组件是否成功获取
//    if (elevator != null && elevatorSwitch != null)
//    {
//      initialSwitchOffset = elevatorSwitch.transform.localPosition - elevator.transform.localPosition;
//    }
//    else
//    {
//      Debug.LogError("Elevator or ElevatorSwitch is not assigned or found.");
//    }
//  }

//  private void Update()
//  {
//    if (elevator != null && elevatorSwitch != null && elevator.isMove)
//    {
//      elevatorSwitch.FollowElevator(elevator.transform.position, initialSwitchOffset);
//      Debug.Log(elevatorSwitch.transform.position);
//    }
//  }
//}
