using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillController : MonoBehaviour
{
    //private SkillList skillList;
    public TextMeshProUGUI skill1times;//用于记录使用次数
    public TextMeshProUGUI skill2times;
    public int SkillOneTimes;
    public int SkillTwoTimes;
    private bool Skill1 = false;
    private void Start()
    {
        SkillOneTimes = 9;
        SkillTwoTimes = 8;
        RefreshUI();
    }
    public void RefreshUI()
    {
        skill1times.SetText(SkillOneTimes.ToString());
        skill2times.SetText(SkillTwoTimes.ToString());
    }
    private void Update()
    {
        if(Skill1==false&&Input.GetKeyDown(KeyCode.L))
        {
            Skill1 = true;
        }
        else if(Skill1==true && Input.GetKeyDown(KeyCode.L))
        {
            Skill1 = false;
            if (SkillOneTimes>=1)
            {
                SkillOneTimes--;
            }
            //skillList.GetSkilllist()[0].UseTime--;
            RefreshUI();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.RightShift))
        {
            if (SkillTwoTimes >= 1)
            {
                SkillTwoTimes--;
            }
            RefreshUI();
        }
    }
}
