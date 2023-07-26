using UnityEngine;

public class CollectableInteraction : Interactable
{
    [Header("Interaction")]
    public InteractionType interactionType = InteractionType.Collectable;
    [SerializeField] private Item item;

    public override void Interact(PlayerInteraction playerInteraction)
    {
        switch (interactionType)
        {
            case InteractionType.Event:
                Event();
                break;
            case InteractionType.Collectable:
                Collectable();
                break;
            case InteractionType.Note:
                Note();
                break;
        }
    }

    public override void Collectable()
    {
        PlayerInventory.Instance.AddItem(item);
        Destroy(gameObject);
    }

    public override void Event()
    {
    }

    public override void Note()
    {
    }
}
