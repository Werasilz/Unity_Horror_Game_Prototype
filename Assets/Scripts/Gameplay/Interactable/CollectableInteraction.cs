using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CollectableInteraction : Interactable
{
    private InteractionType interactionType = InteractionType.Collectable;

    [Header("Collectable")]
    [SerializeField] private Item item;

    [Header("Event")]
    [SerializeField] private EventType eventType;
    [SerializeField] private EventAction[] eventActions;
    private bool isEventAction;

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
            case InteractionType.Hide:
                Hide();
                break;
        }
    }

    public override void Collectable()
    {
        // Show inspect window
        if (ItemWindow.Instance.IsOpenWindow == false)
        {
            ItemWindow.Instance.EnableWindow(item);
        }
        // Close inspect window and add item to inventory
        else
        {
            ItemWindow.Instance.DisableWindow();
            PlayerInventory.Instance.AddItem(item);
            Destroy(gameObject);
            Event();
        }
    }

    public override void Event()
    {
        if (isEventAction == false && eventActions.Length > 0)
        {
            StartCoroutine(StartEvent());
        }

        IEnumerator StartEvent()
        {
            isEventAction = true;
            canvas.SetActive(eventType == EventType.OneTimeEvent ? false : true);

            // Call all events
            for (int i = 0; i < eventActions.Length; i++)
            {
                yield return new WaitForSeconds(eventActions[i].delay);
                eventActions[i].action?.Invoke();
            }

            switch (eventType)
            {
                case EventType.OneTimeEvent:
                    // Disable this event interaction
                    this.enabled = false;
                    break;
                case EventType.ManyTimeEvent:
                    // Reset flag for next event
                    isEventAction = false;
                    break;
            }
        }
    }

    public override void Note()
    {
    }

    public override void Hide()
    {
    }
}
