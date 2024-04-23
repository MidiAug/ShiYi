using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    public GameObject maincamera;
    //æ≤“ÙªÚ’ﬂΩ‚≥˝æ≤“Ù
    public void IfMute()
    {
        if(maincamera != null)
        {
            if(maincamera.GetComponent<AudioSource>().mute == false)
            maincamera.GetComponent<AudioSource>().mute = true;
            else
                maincamera.GetComponent<AudioSource>().mute = false;
        }
    }
}
