using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeManager
{
    private ItemScriptableObject[] items;

    private static RecipeManager _instance;

    public static RecipeManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new RecipeManager();
                _instance.items = Resources.LoadAll("Items", typeof(ItemScriptableObject)).
                                    Cast<ItemScriptableObject>().ToArray();
                
                
                Debug.Log(_instance.items[0].name);
                Debug.Log(_instance.items[1].name);
                Debug.Log(_instance.items[2].name);

                List<string> list = new List<string>();
                list.Add(_instance.items[0].name);
                list.Add(_instance.items[2].name);

                Debug.Log(_instance.CraftItem(list).name);
            }

            return _instance;
        }
    }
    // Returns null if failed
    public ItemScriptableObject CraftItem(List<ItemScriptableObject> recipe){
        List<string> names = new List<string>();
        foreach (var ingridient in recipe){
            names.Add(ingridient.name);
        }
        foreach (var item in items)
        {
            if(item.isRecipe(names)){
               return item;
            }
        }
        return null;
    }
    /*
    // Returns null if failed
    public ItemScriptableObject CraftItem(List<ItemScriptableObject> recipe){
        List<string> names = new List<string>();

        return null;
    }\
    */
    // Returns null if failed
    public ItemScriptableObject CraftItem(List<string> recipe){
        foreach (var item in items)
        {
            if(item.isRecipe(recipe)){
                return item;
            }
        }
        return null;
    }
    
    void Awake() // Is this function needed? This isnt a monobehaviour.
    {
        _instance = this;
    }
}