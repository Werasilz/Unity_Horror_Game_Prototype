using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : SceneSingleton<PlayerInventory>
{
    [Header("Item List")]
    [SerializeField] private List<Item> items;
    public List<Item> GetItems => items;

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
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == removeItem.itemName)
            {
                items.Remove(items[i]);
            }
        }
    }
}
