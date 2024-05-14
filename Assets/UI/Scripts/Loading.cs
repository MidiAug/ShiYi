using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float time = 5f; // 5秒后加载下一个场景
    void Awake()
    {
        Invoke("LoadNextScene", time); // 5秒后加载下一个场景
    }

    void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
