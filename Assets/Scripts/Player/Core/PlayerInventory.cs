using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : SceneSingleton<PlayerInventory>
{
    [Header("Item List")]
    [SerializeField] private List<Item> items;

    private void Start()
    {
        items = new List<Item>();
    }

    public void AddItem(Item newItem)
    {
        Item createdItem = ScriptableObject.CreateInstance<Item>();
        createdItem.Init(newItem);
        items.Add(createdItem);
    }

    public void RemoveItem(Item removeItem)
    {
        items.Remove(removeItem);
    }
}
