using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    public GameObject objectToShow1; // 需要显示的子物体
    public GameObject objectToShow2;
    public GameObject objectToHide1;//需要隐藏的子物体
    public GameObject objectToHide2;
    public GameObject objectToHide3;
    public GameObject objectToHide4;
    void Start()
    {
        // 初始时隐藏子物体
        if (objectToShow1 != null&& objectToShow2!=null)
        {
            objectToShow1.SetActive(false);
            objectToShow2.SetActive(false);
        }
    }

    public void ShowObject()
    {
        // 显示子物体
        if (objectToShow1 != null && objectToShow2 != null)
        {
            objectToShow1.SetActive(true);
            objectToShow2.SetActive(true);
        }
        objectToHide1.SetActive(false);
        objectToHide2.SetActive(false);
        objectToHide3.SetActive(false);
        objectToHide4.SetActive(false);
    }

    
}
