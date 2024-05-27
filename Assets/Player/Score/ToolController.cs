using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    public GameObject Fist;
    public GameObject Draw;
    public GameObject FistDrop;
    public GameObject DrawDrop;
    public Vector2 FirstPosition;
    public Vector2 SecondPosition;
    public GameObject player;//挂载玩家
    public bool HaveFirst1 = false;
    public bool HaveFirst2 = false;
    public float speed = 200.0f;
    private void Update()
    {
        speed = 300.0f;
        if (player.gameObject.GetComponent<Playercontroller>().HaveFist == true)//播放得到道具五祖拳
        {
            FistDrop.SetActive(true);
            Wait1();
        }
        if (player.gameObject.GetComponent<Playercontroller>().HaveDraw == true)//播放得到道具永春纸质画
        {
            DrawDrop.SetActive(true);
            Wait2();
        }
    }
    private void GetFist()
    {
        Vector2 position1 = FistDrop.transform.position;
        Vector2 position2;
        if (HaveFirst2 == false)
        {
            position2 = Fist.transform.position;
            HaveFirst1 = true;
        }
        else
        {
            position2 = Draw.transform.position;
        }
        FistDrop.transform.position = Vector2.MoveTowards(position1, position2, speed * Time.deltaTime);
    }
    private bool move = false;
    private void GetDraw()
    {
        Vector2 position1 = DrawDrop.transform.position;
        Vector2 position2;
        if (HaveFirst1 == false)
        {
            position2 = Fist.transform.position;
            HaveFirst2 = true;
        }
        else
        {
            position2 = Draw.transform.position;
        }
        DrawDrop.transform.position = Vector2.MoveTowards(position1, position2, speed * Time.deltaTime);
    }
    void Wait1()
    {
        FistDrop.SetActive(true);
        StartCoroutine(DelayGetFist(1.0f));
    }
    IEnumerator DelayGetFist(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetFist();
    }
    void Wait2()
    {
        DrawDrop.SetActive(true);
        StartCoroutine(DelayGetDraw(1.0f));
    }
    IEnumerator DelayGetDraw(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetDraw();
    }
}
