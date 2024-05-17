using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetBegin : MonoBehaviour

{
    public GameObject chose1Image; // ���ڴ洢��ʾ��
    private bool isMouseOver = false;
    public Button myButton; // ��ť����
    public string nextSceneName; // Ŀ�곡��������
    void Start()
    {
        // ȷ��Chose1ͼ���ڿ�ʼʱ�����ص�
        if (chose1Image != null)
        {
            chose1Image.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Chose1 image is not assigned.");
        }
        myButton.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        StartCoroutine(LoadSceneAfterDelay(3f));
    }
    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }
    // �������밴ťʱ���ô˷���
    public void OnPointerEnter()
    {
        if (chose1Image != null && !isMouseOver)
        {
            chose1Image.SetActive(true);
            isMouseOver = true;
        }
    }

    // ������뿪��ťʱ���ô˷���
    public void OnPointerExit()
    {
        if (chose1Image != null && isMouseOver)
        {
            chose1Image.SetActive(false);
            isMouseOver = false;
        }
    }
}
