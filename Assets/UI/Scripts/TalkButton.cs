using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject talkUI;
    public Playercontroller playerController;

    private bool playerInRange = false;
    private bool isTalking = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.R))
        {
            talkUI.SetActive(true);
            isTalking = true;

            // 禁用角色控制器
            if (playerController != null)
            {
                playerController.enabled = false;
            }
        }

        // 当谈话UI处于活动状态时，禁用角色控制器
        if (isTalking && Input.GetKeyDown(KeyCode.Escape)) // 如果你希望按下某个键来关闭对话框，这里我使用了 Escape 键
        {
            talkUI.SetActive(false);
            isTalking = false;

            // 启用角色控制器
            if (playerController != null)
            {
                playerController.enabled = true;
            }
        }
    }
}
