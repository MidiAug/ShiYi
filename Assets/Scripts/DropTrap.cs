using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrap : MonoBehaviour
{
    private Rigidbody2D rb; 
    private Vector2 initialPosition; // ���ڼ�¼����ĳ�ʼλ��
    private bool hasFallen = false; // ���ڸ��������Ƿ��Ѿ�����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        rb.gravityScale = 0; // ��ʼʱ������Ϊ0����������Ӱ��
        initialPosition = transform.position; // ��¼����ĳ�ʼλ��
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
        ResetPosition(); // �ָ�ԭλ��
    }

    void ResetPosition()
    {
        rb.velocity = Vector2.zero; // ����ٶ�
        transform.position = initialPosition; // �ƻس�ʼλ��
        rb.gravityScale = 0; // ������������Ϊ0
        hasFallen = false; // ��������״̬
    }
}
