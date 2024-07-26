using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombinationManager
{
    private Gesture[] _gestures;
    private SkillData[] _skillDatas;
    private Skill[] _skills;

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
        return null;
    }

    public Gesture GetGesture(int index)
    {
        return _gestures[index];
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