using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 7f;
    int Jumpnum = 1;//跳跃次数
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
    float dashDist = 5f;  // 闪现距离
    Vector2 dashDirection = new Vector2(dirX, 0).normalized;
    Vector2 offset = dashDirection * 0.1f;  // 在玩家前方稍作偏移
    Vector2 startPosition = new Vector2(transform.position.x,transform.position.y) + offset;  // 调整射线起始位置
    Vector2 dashPosition = startPosition + dashDirection * dashDist;

    if (isDash)
    {
      // 使用LayerMask来忽略玩家自身的层
      int layerMask = 1 << LayerMask.NameToLayer("player");
      layerMask = ~layerMask;  // 反转LayerMask，忽略"Player"层

      RaycastHit2D hit = Physics2D.Raycast(startPosition, dashDirection, dashDist, layerMask);
      if (hit.collider != null)  // 如果射线投射检测到了障碍物
      {
        dashPosition = hit.point;  // 将dash终点设置为碰撞点位置
        dashPosition -= dashDirection * 0.1f;  // 留出一点空间，避免卡在障碍物上
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
