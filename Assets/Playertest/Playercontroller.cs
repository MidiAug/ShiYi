using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    //�����������
    private float moveSpeed = 5f;
    public float maxHp = 100;
    public float curHp;
    public float speed = 7f;
    public bool die = false;
    public bool isInvincible;//�ж��Ƿ��޵�
    private float invincibleTime = 1f;//�޵�ʱ��
    private float invincibleTimer;//��ʱ��

    private Animator animator;//���ﶯ��

    int Jumpnum = 1;//��Ծ����
    bool isDash = false;
    float dirX;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        invincibleTimer = 0;
        curHp = maxHp;
    }
    // Update is called once per frame
    private bool facingRight = false; // Ĭ�Ͻ�ɫ�����ұ�

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        //�޵м�ʱ
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;//����ʱ����
            }
        }

        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && Jumpnum == 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            Jumpnum = 0;
        }
        if (rb.velocity.y == 0)
        {
            Jumpnum = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isDash = true;
        if (Input.GetKeyUp(KeyCode.A))
        {
            // �����ǰ����Ϊ�ұߣ���ı䳯��Ϊ���
            if (facingRight)
            {
                FlipDirection();
            }
        }

        // ���D���ɿ�
        if (Input.GetKeyUp(KeyCode.D))
        {
            // �����ǰ����Ϊ��ߣ���ı䳯��Ϊ�ұ�
            if (!facingRight)
            {
                FlipDirection();
            }
        }

        // ���A�����£��ҵ�ǰ����������
        if (Input.GetKey(KeyCode.A) && facingRight)
        {
            FlipDirection();
        }

        // ���D�����£��ҵ�ǰ����������
        if (Input.GetKey(KeyCode.D) && !facingRight)
        {
            FlipDirection();
        }
    }
    void FlipDirection()
    {
        // ��ת����
        facingRight = !facingRight;

        // ��ת��ɫ��ˮƽ�������ı䳯��
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void FixedUpdate()
    {
        float dashDist = 5f;  // ���־���
        Vector2 dashDirection = new Vector2(dirX, 0).normalized;
        Vector2 offset = dashDirection * 0.1f;  // �����ǰ������ƫ��
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y) + offset;  // ����������ʼλ��
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
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(dirX, moveY).normalized;
        Debug.Log("moveX:" + dirX + "moveY:" + moveY);
        animator.SetFloat("Horizontal", dirX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("speed", moveDirection.sqrMagnitude);

    }

    Vector2 position;
    private bool IsBack = false;
    private void Back()
    {
        if (IsBack == false)
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
    public void changeHealth(float amount)
    {
        if (amount < 0)//�˺�С��0
        {
            if (isInvincible == true)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = invincibleTime;
        }
        curHp = Mathf.Clamp(curHp + amount, 0, maxHp);
        Debug.Log(curHp + "/" + maxHp);
    }

}