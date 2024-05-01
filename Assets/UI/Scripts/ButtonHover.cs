using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    public GameObject objectToShow1; // ��Ҫ��ʾ��������
    public GameObject objectToShow2;
    public GameObject objectToHide1;//��Ҫ���ص�������
    public GameObject objectToHide2;
    public GameObject objectToHide3;
    public GameObject objectToHide4;
    void Start()
    {
        // ��ʼʱ����������
        if (objectToShow1 != null&& objectToShow2!=null)
        {
            objectToShow1.SetActive(false);
            objectToShow2.SetActive(false);
        }
    }

    public void ShowObject()
    {
        // ��ʾ������
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
