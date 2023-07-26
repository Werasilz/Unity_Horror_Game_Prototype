using UnityEngine;

public class NoteInteraction : Interactable
{
    private InteractionType interactionType = InteractionType.Note;

    [Header("Note")]
    [SerializeField] private Note note;

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
        if (NoteWindow.Instance.IsOpenNote == false)
        {
            NoteWindow.Instance.EnableWindow(note.header, note.description);
        }
        else
        {
            NoteWindow.Instance.DisableWindow();
        }
    }
}
