using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathCommentaries : MonoBehaviour
{
    [SerializeField]
    public TMP_Text _bigText;
    [SerializeField]
    public TMP_Text _smallText;

    [SerializeField]
    private List<DeathCommentaryPair> _titles;

    [SerializeField]
    private List<DeathCommentaryPair> _descriptions;

    private PlayerDeath _playerDeath;

    [Serializable]
    public class DeathCommentaryPair
    {
        public DamageType type;
        public string text;
    }
    void Start()
    {
        _playerDeath = FindFirstObjectByType<PlayerDeath>();
        _playerDeath.Death.AddListener(SetText);
    }

    private void SetText(DamageType type)
    {
        _bigText.text = pickRandElement(_titles, type).text;
        _smallText.text = pickRandElement(_descriptions, type).text;
    }

    private DeathCommentaryPair pickRandElement(List<DeathCommentaryPair> elements, DamageType type)
    {
        DeathCommentaryPair randElement = null;
        int count = 0;
        System.Random random = new System.Random();
        foreach (var element in elements)
        {
            if (element.type == type)
            { 
                count = count + 1;
                if (random.Next(count) == 0)
                    randElement = element;
             }
         }
        return randElement;
    }
    void OnDestroy()
    {
        _playerDeath?.Death.RemoveListener(SetText);
    }
}
