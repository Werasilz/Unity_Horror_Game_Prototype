using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EventInteraction : Interactable
{
    private InteractionType interactionType = InteractionType.Event;

    [Header("Event")]
    [SerializeField] private EventType eventType;
    [SerializeField] private EventAction[] eventActions;
    private bool isAction;

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
    }

    public override void Event()
    {
        if (isAction == false)
        {
            StartCoroutine(StartEvent());
        }

        IEnumerator StartEvent()
        {
            isAction = true;
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
                    isAction = false;
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

    [Serializable]
    public struct EventAction
    {
        public float delay;
        public UnityEvent action;
    }

    public enum EventType
    {
        OneTimeEvent,
        ManyTimeEvent,
    }
}
