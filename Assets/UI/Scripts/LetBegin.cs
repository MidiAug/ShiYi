using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LetBegin : MonoBehaviour

{
    public GameObject chose1Image; // 用于存储显示字
    private bool isMouseOver = false;
    public Button myButton; // 按钮对象
    public string nextSceneName; // 目标场景的名称
    void Start()
    {
        // 确保Chose1图像在开始时是隐藏的
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
    // 当鼠标进入按钮时调用此方法
    public void OnPointerEnter()
    {
        if (chose1Image != null && !isMouseOver)
        {
            chose1Image.SetActive(true);
            isMouseOver = true;
        }
    }

    // 当鼠标离开按钮时调用此方法
    public void OnPointerExit()
    {
        if (chose1Image != null && isMouseOver)
        {
            chose1Image.SetActive(false);
            isMouseOver = false;
        }
    }
}
