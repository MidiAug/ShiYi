using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 7f;
    int Jumpnum = 1;//Ã¯‘æ¥Œ ˝
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
    }

  private void FixedUpdate()
  { // …¡œ÷æ‡¿Î
    float dashDist = 5f;
    Vector3 dashPosition = transform.position + new Vector3(dirX, 0, 0) * dashDist;
    if (isDash)
    {
      rb.MovePosition(dashPosition);
      isDash = false;
    }
  }
}
