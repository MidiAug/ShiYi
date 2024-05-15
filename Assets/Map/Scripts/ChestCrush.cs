using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCrush : MonoBehaviour
{
    public GameObject[] itemsToDrop; // 存放要掉落的道具
    public float moveSpeed = 20f; // 宝箱追踪角色的速度
    public bool isTrace = false;  


    private Vector2 initialPosition; // 初始位置
    private bool isOpened = false; //是否已经打开过
    private bool isTracking = false; // 是否正在追踪玩家

    void Start()
    {
        initialPosition = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Playercontroller pc = other.GetComponent<Playercontroller>();
        if (pc != null && !isOpened&&isTrace)
        {
            StartCoroutine(OpenChestAndTrackPlayer());
        }
    }

    IEnumerator OpenChestAndTrackPlayer()
    {
        isOpened = true;

        // 随机选择一个道具掉落
        if (itemsToDrop.Length > 0)
        {
            int randomIndex = Random.Range(0, itemsToDrop.Length);
            Instantiate(itemsToDrop[randomIndex], transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(1.0f);

        // 开始追踪玩家
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            StartCoroutine(TrackPlayer(player));
        }
    }

    IEnumerator TrackPlayer(GameObject player)
    {
        isTracking = true;
        while (isTracking)
        {
            Vector2 targetPosition = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isTracking = false;
                Playercontroller pc = player.GetComponent<Playercontroller>();
                if (pc != null)
                {
                    pc.Respawn();
                    ResetChest();
                }
            }
            yield return null;
        }
    }

    void ResetChest()
    {
        isOpened = false;
        isTracking = false;
        transform.position = initialPosition; // 将宝箱移回初始位置
    }
}
