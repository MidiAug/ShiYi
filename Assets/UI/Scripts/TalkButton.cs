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
            if (!isTalking && Input.GetKeyDown(KeyCode.R)) // 只有当不在对话中时才能触发新的对话
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
        // 当谈话UI处于活动状态时，按下Q键结束对话
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
            playerController.enabled = true; // 在对话结束后重新启用角色控制器
        }
        if (dialogSystem != null)
        {
            dialogSystem.gameObject.SetActive(false);
        }
    }
}
