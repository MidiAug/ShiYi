using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 7f;
    int Jumpnum = 1;//��Ծ����
    bool isDash = false;
    float dirX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        if(Input.GetButtonDown("Jump")&&Jumpnum==1)
        {
            rb.velocity = new Vector2(rb.velocity.x,speed);
            Jumpnum = 0;
        }
        if(rb.velocity.y==0)
        {
            Jumpnum = 1;
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
          isDash = true;
        if(Input.GetKeyDown(KeyCode.L))
        {
            Back();
        }
    }

  private void FixedUpdate()
  {
    float dashDist = 5f;  // ���־���
    Vector2 dashDirection = new Vector2(dirX, 0).normalized;
    Vector2 offset = dashDirection * 0.1f;  // �����ǰ������ƫ��
    Vector2 startPosition = new Vector2(transform.position.x,transform.position.y) + offset;  // ����������ʼλ��
    Vector2 dashPosition = startPosition + dashDirection * dashDist;

    if (isDash)
    {
      // ʹ��LayerMask�������������Ĳ�
      int layerMask = 1 << LayerMask.NameToLayer("player");
      layerMask = ~layerMask;  // ��תLayerMask������"Player"��

      RaycastHit2D hit = Physics2D.Raycast(startPosition, dashDirection, dashDist, layerMask);
      if (hit.collider != null)  // �������Ͷ���⵽���ϰ���
      {
        dashPosition = hit.point;  // ��dash�յ�����Ϊ��ײ��λ��
        dashPosition -= dashDirection * 0.1f;  // ����һ��ռ䣬���⿨���ϰ�����
      }

      rb.MovePosition(dashPosition);
      isDash = false;
    }
  }
  
  Vector2 position;
  private bool IsBack = false;
  private void Back()
  {
      if(IsBack==false)
      {
          position = gameObject.transform.position;
          IsBack = true;
      }
      else
      {
          gameObject.transform.position = position;
          IsBack = false;
      }
  }
}
