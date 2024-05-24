using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    public string targetSceneName;
    public GameObject Dialog;
    public float delay = 1f;
    void OnTriggerEnter2D(Collider2D other)
    {
        Playercontroller pc = other.GetComponent<Playercontroller>();
        if (pc != null)
        {
            DialogSystem dialogSystem = FindObjectOfType<DialogSystem>();
            if (dialogSystem != null)
            {
                dialogSystem.StartDialog(() =>
                {
                    StartCoroutine(LoadSceneWithDelay());
                });
            }
            else
            {
                Debug.LogError("DialogSystem not found in the scene.");
            }
        }
    }
    IEnumerator LoadSceneWithDelay()
    {
        // �ȴ�ָ�����ӳ�ʱ��
        yield return new WaitForSeconds(delay);

        // ����Ŀ�곡��
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
    }
}