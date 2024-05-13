using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
	private Rigidbody2D rb;
	private SpriteRenderer spriteRenderer;
	//�����������
	public float speed = 7f;
	private float dashDist = 5f;  // ���־���
	//private float invincibleTime = 1f;//�޵�ʱ��
	public float jumpCons = 1.8f;  //��Ծϵ�����ٶȳ��Դ�ϵ��Ϊ��Ծʱ��ֱ������ٶ�
	public Vector3 respawnPos= new( -63.13f , 41.83f ,0); // ������λ��
	Vector2 position;
	public GameObject shadow;
	private bool IsBack = false;

	private bool isJump = false;
	private int Jumpnum = 1;//��Ծ����
	public bool die = false;
	public bool isInvincible;//�ж��Ƿ��޵�(����ǲ���û�ã�Ҫ��ɾ�ˣ�) ���õģ����Ե���鿴����ȥ��
	private float invincibleTimer;//��ʱ��
	private Animator animator;//���ﶯ��

	bool isDash = false;
	float dirX;
	public PhysicsMaterial2D noFriction;
	public PhysicsMaterial2D Friction;

	public int dashTimes = 8;
	public int backtimes = 9;
    //��Ч
    private PlayerAudio characterAudio;
    void Start()
	{
		animator = gameObject.GetComponent<Animator>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		invincibleTimer = 0;
		rb.sharedMaterial = Friction;
        characterAudio = GetComponent<PlayerAudio>();
    }

	void Update()
	{
		dirX = Input.GetAxisRaw("Horizontal");
		
		// ˮƽ�˶��Ҹ��ķ���
		moveHorizontal();

		// ��ֱ�����˶�
		moveVertical();

		//�޵м�ʱ
		if (isInvincible)
		{
			invincibleTimer -= Time.deltaTime;
			if (invincibleTimer < 0)
			{
				isInvincible = false;//����ʱ����
			}
		}
		if(Input.GetKeyDown(KeyCode.L)&&backtimes>=0)
        {
			Back();
        }
	}
	private void FixedUpdate()
	{
		// ��̷���
		dashFun();
    // �ٶȴﵽһ��ֵ˵����ˤ����գ�����
		if (rb.velocity.y < -40f)
		{
		  Respawn();
		}
	}

	private void Back()
	{
		if (IsBack == false)
		{
			position = gameObject.transform.position;
			IsBack = true;
			shadow.SetActive(true);
			shadow.transform.position = new Vector2(position.x, position.y);
		}
		else
		{
			gameObject.transform.position = position;
			IsBack = false;
			backtimes--;
			shadow.SetActive(false);
		}
	}
		
	// ���½�ɫ�����λ��
	public void UpdateRespawnPos(Vector3 newRespawnPos)
	{
		respawnPos = newRespawnPos;
		Debug.Log("Respawn position updated to: " + respawnPos);	
	}
		
	public void Respawn()
	{
		transform.position = respawnPos;
	}
	private void moveHorizontal()
	{
		
        if (dirX < 0)
        {
            spriteRenderer.flipX = false;  // �����ƶ�����תͼƬ
        }
        else if (dirX > 0)
        {
            spriteRenderer.flipX = true; // �����ƶ����ָ�ͼƬ
        }

        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.LeftShift)&&dashTimes>1)
        {
			isDash = true;
        }
    }
    private void moveVertical()
    {
        if (Input.GetButtonDown("Jump") && Jumpnum == 1)
        {
            characterAudio.PlayJumpSound();
            rb.velocity = new Vector2(rb.velocity.x, speed * jumpCons);
            Jumpnum = 0;
            rb.sharedMaterial = noFriction;
        }
        //if (rb.velocity.y == 0)
        if (Mathf.Abs(rb.velocity.y) > 0.0001)
        {
            rb.sharedMaterial = noFriction;
        }
        if (Mathf.Abs(rb.velocity.y  )<0.0001)
        {
            Jumpnum = 1;
            rb.sharedMaterial = Friction;
        }
    }

	private void dashFun()
	{
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
						dashTimes--;//���ִ���
        }
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(dirX, moveY).normalized;

        animator.SetFloat("Horizontal", dirX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("speed", moveDirection.sqrMagnitude);
        
    }
}