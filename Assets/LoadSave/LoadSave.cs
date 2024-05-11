using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class GameState
{
  public PlayerState playerState;
  public List<TrapState> traps;
  public ElevatorState elevatorState;
}

[Serializable]
public class PlayerState
{
  public Vector3 position;
  public Vector3 respawnPosition;
  public int dashTimes;
  public int backTimes;
}

[Serializable]
public class TrapState
{
  public TrapCtrl.TrapMode mode;
  public Vector3 position;
  public Vector3 dropTriggerPosition; 
  public float dropTriggerRadius;
  public float upTime;
  public float downTime;
  public bool isTriggered;
}

[Serializable]
public class ElevatorState
{
  public bool isMoving;
  public bool isBackAndForth;
  public float chargeTime;
  public float desireTime;
  public float speed;
  public Vector3 boardPosition; 
  public Vector3 endPosition;
}

public class SaveLoadManager : MonoBehaviour
{
  public GameObject player;
  public ElevatorCtrl elevator;
  public List<TrapCtrl> traps;

  private string saveFilePath;

  void Start()
  {
    saveFilePath = Application.persistentDataPath + "/gamestate.save";
  }

  public void SaveGame()
  {
    GameState gameState = new GameState
    {
      playerState = new PlayerState
      {
        position = player.transform.position,
        respawnPosition = player.GetComponent<Playercontroller>().respawnPos,
        dashTimes = player.GetComponent<Playercontroller>().dashTimes,
        backTimes = player.GetComponent<Playercontroller>().backtimes
      },
      elevatorState = new ElevatorState
      {
        isMoving = elevator.isMove,
        isBackAndForth = elevator.isBackAndForth,
        chargeTime = elevator.chargeTime,
        desireTime = elevator.desireTime,
        speed = elevator.speed,
        boardPosition = elevator.board.transform.position,
        endPosition = elevator.endObj.transform.position
      },
      traps = new List<TrapState>()
    };

    foreach (TrapCtrl trap in traps)
    {
      if (!trap.rb.simulated || trap.isRemain) 
      {
        TrapState trapState = new TrapState
        {
          mode = trap.trapMode,
          position = trap.transform.position,
          dropTriggerPosition = trap.dropTrigglePos.transform.position,
          dropTriggerRadius = trap.dropTriggleRadius,
          upTime = trap.upTime,
          downTime = trap.downTime,
          isTriggered = trap.rb.simulated,
        };
        gameState.traps.Add(trapState);
      }
    }

    BinaryFormatter bf = new();
    using (FileStream file = File.Create(saveFilePath))
    {
      bf.Serialize(file, gameState);
    }

    Debug.Log("Game Saved");
  }

  public void LoadGame()
  {
    if (File.Exists(saveFilePath))
    {
      BinaryFormatter bf = new BinaryFormatter();
      using (FileStream file = File.Open(saveFilePath, FileMode.Open))
      {
        GameState gameState = (GameState)bf.Deserialize(file);

        // Load player state
        player.transform.position = gameState.playerState.position;
        var playerController = player.GetComponent<Playercontroller>();
        playerController.respawnPos = gameState.playerState.respawnPosition;
        playerController.dashTimes = gameState.playerState.dashTimes;
        playerController.backtimes = gameState.playerState.backTimes;

        // Load elevator state
        elevator.isMove = gameState.elevatorState.isMoving;
        elevator.isBackAndForth = gameState.elevatorState.isBackAndForth;
        elevator.chargeTime = gameState.elevatorState.chargeTime;
        elevator.desireTime = gameState.elevatorState.desireTime;
        elevator.speed = gameState.elevatorState.speed;
        elevator.board.transform.position = gameState.elevatorState.boardPosition;
        elevator.endObj.transform.position = gameState.elevatorState.endPosition;

        // Load traps state
        foreach (TrapState trapState in gameState.traps)
        {
          TrapCtrl trap = traps.Find(t => t.transform.position == trapState.position);
          if (trap != null)
          {
            trap.transform.position = trapState.position;
            trap.dropTrigglePos.transform.position = trapState.dropTriggerPosition;
            trap.dropTriggleRadius = trapState.dropTriggerRadius;
            trap.upTime = trapState.upTime;
            trap.downTime = trapState.downTime;

            if (trap.trapMode == TrapCtrl.TrapMode.Drop)
            {
              trap.rb.simulated = trapState.isTriggered;
              trap.rb.gravityScale = trapState.isTriggered ? 3 : 0;
            }
          }
        }
      }
      Debug.Log("Game Loaded");
    }
    else
    {
      Debug.LogError("No save file found.");
    }
  }
}