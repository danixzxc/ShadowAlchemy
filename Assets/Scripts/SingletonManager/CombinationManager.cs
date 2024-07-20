using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombinationManager
{
    private Gesture[] gestures;
    private Skill[] skills;

    private static CombinationManager _instance;

    public static CombinationManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new CombinationManager();
                _instance.gestures = Resources.LoadAll("Gestures", typeof(Gesture)).
                                    Cast<Gesture>().ToArray();
                _instance.skills = Resources.LoadAll("Skills", typeof(Skill)).
                                    Cast<Skill>().ToArray();
            }
            return _instance;
        }
    }
    public Skill CraftItem(Type[] combination)
    {
        foreach (var item in skills)
        {
            if(item.isValid(combination)){
               return item;
            }
        }
        return null;
    }

    public Gesture GetGesture(int index)
    {
        return gestures[index];
    }
}