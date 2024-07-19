using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeManager
{
    private Gesture[] gestures;
    private Skill[] skills;

    private static RecipeManager _instance;

    public static RecipeManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new RecipeManager();
                _instance.gestures = Resources.LoadAll("Gestures", typeof(Gesture)).
                                    Cast<Gesture>().ToArray();
                _instance.skills = Resources.LoadAll("Skills", typeof(Skill)).
                                    Cast<Skill>().ToArray();

              /*  Debug.Log("Gestures");
                Debug.Log(_instance.gestures[0].name);
                Debug.Log(_instance.gestures[1].name);
                Debug.Log(_instance.gestures[2].name);

                Debug.Log("Skills");
                Debug.Log(_instance.skills[0].name);

                Type[] array = new Type[3];
                array[0] = _instance.gestures[0].type;
                array[1] = _instance.gestures[1].type;
                array[2] = _instance.gestures[2].type;

                Debug.Log("Casted skill");
                Debug.Log(_instance.CraftItem(array).name);
              */
            }

            return _instance;
        }
    }
    // Returns null if failed
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
    
    void Awake() // Is this function needed? This isnt a monobehaviour.
    {
        _instance = this;
    }
}