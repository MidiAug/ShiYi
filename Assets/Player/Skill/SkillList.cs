using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillList : MonoBehaviour//��ȡ��Ҽ����б�
{
    public static SkillList Instance { get; set; }
    private void Awake()
    {
        Instance = this;
    }
    public List<SKILL> Skilllist;
    public SkillList()
    {
        Skilllist = new List<SKILL>();
        Skilllist[0] = new SKILL { UseTime = 9, Skilltype = SKILL.SkillTYPE.skill1, SkillName = "tea" };
    }
    public void Additem(SKILL skill)
    {
        int index = 0;
        for (int i = 0; i < Skilllist.Count; i++)
        {
            if (Skilllist[i].Skilltype== skill.Skilltype)
            {
                Skilllist[i].UseTime++;
                break;
            }
            index++;
        }
        if (index == Skilllist.Count)
        {
            Skilllist.Add(skill);
        }
    }
    //��ȡ��Ʒ�б�
    public List<SKILL> GetSkilllist()
    {
        return Skilllist;
    }
}
