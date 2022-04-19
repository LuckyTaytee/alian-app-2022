using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VrAlian
{
    [CreateAssetMenu]

    public class Item : ScriptableObject
    {
        [SerializeField] private string itemName = "Write a name";

        [SerializeField, Multiline] private string description = "does stuff";
        [SerializeField] private Sprite icon = null;
        
        //[SerializeField] private int value = 1;

        [SerializeField] private GameObject prefab = null; //The form that this object takes

        public Sprite Icon => icon;
        public GameObject Prefab => prefab;

        public string ItemName => itemName;
        public string Description => description;
    }
}