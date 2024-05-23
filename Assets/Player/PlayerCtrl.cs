using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
	private SkillController skillController;
    private Rigidbody2D rb;
	private SpriteRenderer spriteRenderer;
	//人物相关属性
	public float speed = 7f;
	private float dashDist = 5f;  // 闪现距离
	//private float invincibleTime = 1f;//无敌时间
	public float jumpCons = 1.8f;  //跳跃系数，速度乘以此系数为跳跃时竖直方向的速度
	public Vector3 respawnPos= new( -63.13f , 41.83f ,0); // 重生的位置
	Vector2 position;
	public GameObject shadow;
	private bool IsBack = false;
	private bool isJump = false;

	public int dashTimes = 9;
	public int backtimes = 9;
	private int Jumpnum = 1;//跳跃次数
	public bool die = false;
	public bool isInvincible;//判断是否无敌(这个是不是没用，要不删了？) 有用的，可以点击查看引用去找
	private float invincibleTimer;//计时器
	private Animator animator;//人物动画

	bool isDash = false;
	float dirX;
	public PhysicsMaterial2D noFriction;
	public PhysicsMaterial2D Friction;

	public int Score = 0;
	public char Notice='0';
    //音效
    private PlayerAudio characterAudio;
    void Start()
	{
		animator = gameObject.GetComponent<Animator>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		invincibleTimer = 0;
		rb.sharedMaterial = Friction;
        characterAudio = GetComponent<PlayerAudio>();
		skillController = GameObject.Find("SkillController").GetComponent<SkillController>();
    }

	void Update()
	{
		dirX = Input.GetAxisRaw("Horizontal");
		
		// 水平运动且更改方向
		moveHorizontal();

		// 竖直方向运动
		moveVertical();

		//无敌计时
		if (isInvincible)
		{
			invincibleTimer -= Time.deltaTime;
			if (invincibleTimer < 0)
			{
				isInvincible = false;//倒计时结束
			}
		}
		if(Input.GetKeyDown(KeyCode.L)&&skillController.couldUse(1))
        {
			Back();
        }
	}
	private void FixedUpdate()
	{
		// 冲刺方法
		dashFun();
    // 速度达到一定值说明会摔入虚空，复活
		if (rb.velocity.y < -60f)
		{
			Debug.Log("fuck");
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
			skillController.useSkill(1);
			shadow.SetActive(false);
		}
	}
		
	// 更新角色复活的位置
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
            spriteRenderer.flipX = false;  // 向左移动，翻转图片
        }
        else if (dirX > 0)
        {
            spriteRenderer.flipX = true; // 向右移动，恢复图片
        }

        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.LeftShift) && skillController.couldUse(2) && rb.velocity !=Vector2.zero)
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
        Vector2 offset = dashDirection * 0.1f;  // 在玩家前方稍作偏移
        Vector2 startPosition = new Vector2(transform.position.x, transform.position.y) + offset;  // 调整射线起始位置
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
			skillController.useSkill(2);
        }
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(dirX, moveY).normalized;

        animator.SetFloat("Horizontal", dirX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("speed", moveDirection.sqrMagnitude);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
		// 碰到电梯成为子物体
		if (collision.gameObject.tag == "Elevator")
		{

			transform.SetParent(collision.transform);
		}
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // 退出电梯恢复
        if (collision.gameObject.tag == "Elevator")
        {
			transform.SetParent(null);
        }
    }
}