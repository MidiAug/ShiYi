using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKILL
{
    public string SkillName;
    public int UseTime;
    public enum SkillTYPE
    {
        skill1,
        skill2//后续用非遗名称替代
    }
    public SkillTYPE Skilltype;
}
