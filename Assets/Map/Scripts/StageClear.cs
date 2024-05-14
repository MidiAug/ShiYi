using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : MonoBehaviour
{
    public string targetSceneName;

    public float delay = 1f;
    void OnTriggerEnter2D(Collider2D other)
    {
        Playercontroller pc = other.GetComponent<Playercontroller>();
        if (pc != null) 
        {
            StartCoroutine(LoadSceneWithDelay());
            
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