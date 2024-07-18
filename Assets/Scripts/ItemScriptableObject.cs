using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemScriptableObject", order = 1)]

//public class ItemScriptableObject : ScriptableObject
public class ItemScriptableObject : ScriptableObject, IEquatable<ItemScriptableObject>

{

    [Serializable]
    public class RecipeContainer : IEnumerable<RecipeContainer>
    {
        public List<string> container;
        
        IEnumerator<RecipeContainer> IEnumerable<RecipeContainer>.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
            //return new RecipeContainerEnum(container);
        }
        public RecipeContainerEnum GetEnumerator()
    {
        return new RecipeContainerEnum(container);
    }

    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class RecipeContainerEnum : IEnumerator<RecipeContainer>
    {
        public List<string> _strings;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public RecipeContainerEnum(List<string> list)
        {
            _strings = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _strings.Count());
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
            // I hope there is no memory leak.
            // Let the Garbage collector save our soul.
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public string Current
        {
            get
            {
                try
                {
                    return _strings[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        //RecipeContainer IEnumerator<RecipeContainer>.Current => throw new NotImplementedException();

        public RecipeContainer AWESOMECurrent(){
            RecipeContainer rec = new RecipeContainer();
            rec.container = _strings;
            return rec;
        }

        RecipeContainer IEnumerator<RecipeContainer>.Current => AWESOMECurrent();
    }

    public string name;
    public string id;
    public Sprite sprite;
    public List<RecipeContainer> recipes;
    
    public bool Equals(ItemScriptableObject other)
    {
        if (other is null)
            return false;

        return this.id == other.id;
    }

    public override bool Equals(object obj) => Equals(obj as ItemScriptableObject);
    
    public bool isRecipe(List<string> recipe)
    {
        List<string> firstNotSecond;
        foreach (var tempRecipe in  recipes)
        {
            firstNotSecond = recipe.Where(i => !tempRecipe.Any(x => x.container.Contains(i))).ToList();
            if (!firstNotSecond.Any())
               return true;
        }
        return false;
    }
}