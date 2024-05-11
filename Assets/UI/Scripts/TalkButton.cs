using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject talkUI;
    public Playercontroller playerController;
    public DialogSystem dialogSystem;

    private bool playerInRange = false;
    private bool isTalking = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (!isTalking && Input.GetKeyDown(KeyCode.R)) // ֻ�е����ڶԻ���ʱ���ܴ����µĶԻ�
            {
                StartTalking();
            }
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
        // ��̸��UI���ڻ״̬ʱ������Q�������Ի�
        if (isTalking && Input.GetKeyDown(KeyCode.Q))
        {
            EndTalking();
        }
    }

    private void StartTalking()
    {
        talkUI.SetActive(true);
        isTalking = true;
        if (playerController != null)
        {
            playerController.enabled = false;
        }
        if (dialogSystem != null)
        {
            dialogSystem.gameObject.SetActive(true);
        }
    }

    public void EndTalking()
    {
        talkUI.SetActive(false);
        isTalking = false;
        if (playerController != null)
        {
            playerController.enabled = true; // �ڶԻ��������������ý�ɫ������
        }
        if (dialogSystem != null)
        {
            dialogSystem.gameObject.SetActive(false);
        }
    }
}
