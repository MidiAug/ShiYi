using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class TrapCtrl : MonoBehaviour
{
    // 陷阱模式
    public enum TrapMode
    {
        // 固定，掉落，弹出收回的三种陷阱
        Fixed,
        Drop,
        PopUp
    }
    public TrapMode trapMode;

    // 掉落陷阱的触发位置与判定范围半径
    public GameObject dropTrigglePos;
    public float dropTriggleRadius = 1f;
    public float gravityScale = 1.0f;
    private float timeToLive = 3f;
    private float curLiveTime = 0f;
    private GameObject player;
    private Rigidbody2D rb;

    // 弹出收回陷阱的弹出收回时间
    public float upTime;
    public float downTime;
    private bool isPop = true;
    private float deltaTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (trapMode == TrapMode.Fixed) fixedInit();
        else if (trapMode == TrapMode.Drop) dropInit();
        else if (trapMode == TrapMode.PopUp) popUpInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (trapMode == TrapMode.Fixed) fixedFun();
        else if (trapMode == TrapMode.Drop) dropFun();
        else if (trapMode == TrapMode.PopUp) popUpFun();
    }
    void fixedInit()
    {

    }
    void fixedFun()
    {
        
    }
    
    void dropInit()
    {
        player = GameObject.FindWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.simulated = false;

    }
    void dropFun()
    {
        // 触发
        Vector3 trigglePos = dropTrigglePos.transform.position;
        float disBetweenTriggleAndPlayer = Vector2.Distance(trigglePos, player.transform.position);
        //Debug.Log(trigglePos);
        if (disBetweenTriggleAndPlayer < dropTriggleRadius)
        {
            rb.simulated = true;
            rb.gravityScale = 3;
        }
            if (rb.simulated == true)
        {
            curLiveTime += Time.deltaTime;
            if(curLiveTime > timeToLive)
            {
                Destroy(gameObject);
            }
        }

        
    }

    void popUpInit()
    {

    }
    void popUpFun()
    {
        if(isPop)
        {
            deltaTime += Time.deltaTime;
            if(deltaTime > upTime)
            {
                deltaTime = 0;
                isPop = false;
                Color currentColor = transform.GetComponent<SpriteRenderer>().color;
                transform.GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 0);
                transform.GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
        else
        {
            deltaTime += Time.deltaTime;
            if (deltaTime > downTime)
            {
                deltaTime = 0;
                isPop = true;
                Color currentColor = transform.GetComponent<SpriteRenderer>().color;
                transform.GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.g, currentColor.b, 1);
                transform.GetComponent<PolygonCollider2D>().enabled = true;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Playercontroller playercontroller = other.GetComponent<Playercontroller>();
        if(playercontroller != null)
        {
            playercontroller.Respawn();
            if (trapMode == TrapMode.Drop) Destroy(gameObject);
        }
    }
}
