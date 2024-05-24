using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillController : MonoBehaviour
{
    //private SkillList skillList;
    public TextMeshProUGUI skill1times;//���ڼ�¼ʹ�ô���
    public TextMeshProUGUI skill2times;
    public int SkillOneTimes;
    public int SkillTwoTimes;
    public Transform player;
    private Playercontroller playerController;
    private bool Skill1 = false;

    // �����ܴ���Ϊ0ʱ��������Ч��ͼ��䰵
    public Transform skill1;
    private SpecialEffect specialEffect;
    private void Start()
    {
        playerController = player.GetComponent<Playercontroller>();
        SkillOneTimes = playerController.backtimes;
        SkillTwoTimes = playerController.dashTimes;
        specialEffect = skill1.GetComponent<SpecialEffect>();
        RefreshUI();
    }
    public void RefreshUI()
    {
        skill1times.SetText(SkillOneTimes.ToString());
        skill2times.SetText(SkillTwoTimes.ToString());
    }
    public void useSkill(int whichOne)
    {
        if (whichOne == 1)
        {
            SkillOneTimes--;
            if (SkillOneTimes == 0) specialEffect.banTheSkill();
        }
        else if (whichOne == 2)
        {
            SkillTwoTimes--;
        }
        RefreshUI();
    }
    public bool couldUse(int whichOne)
    {
        if (whichOne == 1)
        {
            return SkillOneTimes > 0;
        }
        else if (whichOne == 2)
        {
            return SkillTwoTimes > 0;
        }
        return false;
    }

}
