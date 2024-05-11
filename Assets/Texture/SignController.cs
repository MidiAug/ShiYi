using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour
{
    public GameObject background;
    private bool isTrigger = false;
    void Update()
    {
        if(isTrigger==true)
        {
            background.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;
        background.SetActive(false);
    }
}
