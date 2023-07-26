using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Data/Item")]
public class Item : ScriptableObject
{
    public string itemName;

    [TextArea(10, 100)]
    public string description;

    public GameObject itemPrefab;

    public void Init(Item newItem)
    {
        name = newItem.name + "#" + GetInstanceID();
        itemName = newItem.itemName;
        description = newItem.description;
        itemPrefab = newItem.itemPrefab;
    }
}
