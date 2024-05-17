using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public GameObject player;
    //private Playercontroller playercontroller;
    public TextMeshProUGUI Score;
    void Update()
    {
        Score.SetText(player.gameObject.GetComponent<Playercontroller>().Score.ToString());
        //Score.SetText("1");
        //player.gameObject.GetComponent<Playercontroller>().Score++;
    }
}
