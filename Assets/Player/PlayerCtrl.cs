using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
	private SkillController skillController;
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
	private BoxCollider2D boxCollider2D;

	public int dashTimes = 9;
	public int backtimes = 9;
	private int Jumpnum = 1;//��Ծ����
	public bool die = false;
	public bool isInvincible;//�ж��Ƿ��޵�(����ǲ���û�ã�Ҫ��ɾ�ˣ�) ���õģ����Ե���鿴����ȥ��
	private float invincibleTimer;//��ʱ��
	private Animator animator;//���ﶯ��

	

	bool isDash = false;
	float dirX;
	public PhysicsMaterial2D noFriction;
	public PhysicsMaterial2D Friction;

	public int Score = 0;
	public char Notice='0';
    //��Ч
    private PlayerAudio characterAudio;

	// ������Ӱ��Ч
	public float shadowAniSpeed; // �ٶ�
    public float shadowAniScale;
	private Vector3 shadowOriScale;
	private Color shadowOriColor;
	private SpriteRenderer shadowRenderer;
    void Start()
	{
		animator = gameObject.GetComponent<Animator>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		invincibleTimer = 0;
		rb.sharedMaterial = Friction;
        characterAudio = GetComponent<PlayerAudio>();
		skillController = GameObject.Find("SkillController").GetComponent<SkillController>();
		boxCollider2D = GetComponent<BoxCollider2D>();

		shadowRenderer = shadow.transform.GetComponent<SpriteRenderer>();
        shadowOriScale = shadow.transform.localScale;
		shadowOriColor = shadowRenderer.color;
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
		if(Input.GetKeyUp(KeyCode.L)&&skillController.couldUse(1))
        {
			Back();
        }
	}
	private void FixedUpdate()
	{
		// ��̷���
		dashFun();
    // �ٶȴﵽһ��ֵ˵����ˤ����գ�����
		if (rb.velocity.y < -60f)
		{
			Debug.Log("fuck");
		  Respawn();
		}
	}

	private float lastshadowAniTime = 0;
    IEnumerator setShadow()
    {
		while (true)
		{
			 // ��Ч����
			if(shadow.transform.localScale.x - shadowOriScale.x<0.001&& shadowRenderer.color.a >254/255.0f)
			{
                break;
			}
            shadow.transform.localScale = Vector3.Lerp(shadow.transform.localScale, shadowOriScale,Time.deltaTime*shadowAniSpeed);
            shadowRenderer.color = Color.Lerp(shadowRenderer.color, shadowOriColor,Time.deltaTime * shadowAniSpeed);
            yield return null;

        }
    }

    private void Back()
	{
		if (IsBack == false)
		{
			position = gameObject.transform.position;
			IsBack = true;
			if (spriteRenderer.flipX)
			{
				shadow.transform.GetComponent<SpriteRenderer>().flipX = true;
            }
			else 
			{
				shadow.transform.GetComponent<SpriteRenderer>().flipX = false;
            }
			shadow.SetActive(true);
			shadowRenderer.color = new Color(shadowOriColor.r, shadowOriColor.g, shadowOriColor.b, 0); // ͸��
			shadow.transform.localScale = shadowOriScale*shadowAniScale; // ��
			StartCoroutine(setShadow());
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


        if (Input.GetKeyUp(KeyCode.LeftShift) && skillController.couldUse(2) && rb.velocity !=Vector2.zero)
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
		// �������ݳ�Ϊ������
		if (collision.gameObject.tag == "Elevator")
		{

			transform.SetParent(collision.transform);

		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		// �˳����ݻָ�
		if (collision.gameObject.tag == "Elevator")
		{
			transform.SetParent(null);
		}
	}

}