//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ElevatorSystemCtrl : MonoBehaviour
//{
//  public ElevatorSwitchCtrl elevatorSwitch; // ����Ϊ���У�������Inspector�и�ֵ
//  public ElevatorCtrl elevator; // ����Ϊ���У�������Inspector�и�ֵ
//  private Vector3 initialSwitchOffset; // ��������ڵ��ݵĳ�ʼƫ��

//  private void Start()
//  {
//    Debug.Log(initialSwitchOffset);
//    // ȷ�����Ӷ����л�ȡ���
//    if (elevator == null)
//    {
//      elevator = GetComponentInChildren<ElevatorCtrl>();
//    }

//    if (elevatorSwitch == null)
//    {
//      elevatorSwitch = GetComponentInChildren<ElevatorSwitchCtrl>();
//    }

//    // �������Ƿ�ɹ���ȡ
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
