using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrap : MonoBehaviour
{
    private Rigidbody2D rb; 
    private Vector2 initialPosition; // 用于记录物体的初始位置
    private bool hasFallen = false; // 用于跟踪物体是否已经下落

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.gravityScale = 0; // 初始时先设置为0，不受重力影响
        initialPosition = transform.position; // 记录物体的初始位置
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Playercontroller pc = other.GetComponent<Playercontroller>();
        if (pc != null && !hasFallen)
        {
            hasFallen = true; 
            rb.gravityScale = 1; 
            StartCoroutine(RespawnAfterDelay(pc));
        }
    }

    IEnumerator RespawnAfterDelay(Playercontroller pc)
    {
        yield return new WaitForSeconds(1.0f); 
        pc.Respawn(); 
        yield return new WaitForSeconds(1.0f); 
        ResetPosition(); // 恢复原位置
    }

    void ResetPosition()
    {
        rb.velocity = Vector2.zero; // 清空速度
        transform.position = initialPosition; // 移回初始位置
        rb.gravityScale = 0; // 重力重新设置为0
        hasFallen = false; // 重置下落状态
    }
}
