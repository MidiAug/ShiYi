using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCrush : MonoBehaviour
{
    public GameObject[] itemsToDrop; // ���Ҫ����ĵ���
    public float moveSpeed = 20f; // ����׷�ٽ�ɫ���ٶ�
    public bool isTrace = false;  


    private Vector2 initialPosition; // ��ʼλ��
    private bool isOpened = false; //�Ƿ��Ѿ��򿪹�
    private bool isTracking = false; // �Ƿ�����׷�����

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

        // ���ѡ��һ�����ߵ���
        if (itemsToDrop.Length > 0)
        {
            int randomIndex = Random.Range(0, itemsToDrop.Length);
            Instantiate(itemsToDrop[randomIndex], transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(1.0f);

        // ��ʼ׷�����
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
        transform.position = initialPosition; // �������ƻس�ʼλ��
    }
}
