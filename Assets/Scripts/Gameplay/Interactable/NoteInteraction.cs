using UnityEngine;

public class NoteInteraction : Interactable
{
    public InteractionType interactionType = InteractionType.Note;

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
    }

    public override void Event()
    {
    }

    public override void Note()
    {
    }
}
