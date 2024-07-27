using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombinationManager
{
    private Gesture[] _gestures;
    private SkillData[] _skillDatas;
    private Skill[] _skills;
    private SkillsCharacteristics _skillsCharacteristics;

    public Dictionary<Type, Gesture> gestures;

    private static CombinationManager _instance;

    public static CombinationManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new CombinationManager();
                _instance._gestures = Resources.LoadAll("Gestures", typeof(Gesture)).
                                    Cast<Gesture>().ToArray();
                _instance._skillDatas = Resources.LoadAll("Skills", typeof(SkillData)).
                                    Cast<SkillData>().ToArray();
                _instance._skillsCharacteristics = Resources.Load("Characteristics/Characteristics", typeof(SkillsCharacteristics)) as SkillsCharacteristics;
                _instance._skills = new Skill[]
                {
                    new DashSkill(),
                    new BackstepSkill(),
                    new JumpSkill(),
                    new WallrunSkill(),
                    new WeightSkill(),
                    new ShurikenSkill(),
                    new SmokeBombSkill(),
                    new HookSkill(),
                    new SwordSkill()
                }; 
            }
            return _instance;
        }
    }
    public Skill CombineSkill(Type[] combination)
    {
        foreach (var item in _skills)
        {
            if(item.data.isValid(combination)){
               return item;
            }
        }
        return new Skill();
    }

    public Gesture GetGesture(int index)
    {
        return _gestures[index];
    }

    public SkillsCharacteristics GetSkillsCharacteristics()
    {
        return _skillsCharacteristics;
    }

    public SkillData GetSkillData(string name)
    {
        foreach(var item in _skillDatas)
        {
            if(item.name == name)
                return item;
        }
        return _skillDatas[1]; // item for none
    }
}