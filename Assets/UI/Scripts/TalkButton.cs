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

            // ���ý�ɫ������
            if (playerController != null)
            {
                playerController.enabled = false;
            }
        }

        // ��̸��UI���ڻ״̬ʱ�����ý�ɫ������
        if (isTalking && Input.GetKeyDown(KeyCode.Escape)) // �����ϣ������ĳ�������رնԻ���������ʹ���� Escape ��
        {
            talkUI.SetActive(false);
            isTalking = false;

            // ���ý�ɫ������
            if (playerController != null)
            {
                playerController.enabled = true;
            }
        }
    }
}
