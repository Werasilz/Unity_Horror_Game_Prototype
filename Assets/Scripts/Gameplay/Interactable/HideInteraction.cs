using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HideInteraction : Interactable
{
    private InteractionType interactionType = InteractionType.Hide;
    [SerializeField] private Collider boxCollider;
    [SerializeField] private Transform exitPoint;
    private PlayerInteraction playerInteraction;
    private bool isHiding;

    [Header("Event")]
    [SerializeField] private EventType eventType;
    [SerializeField] private EventAction[] eventActions;
    private bool isEventAction;

    public override void Interact(PlayerInteraction playerInteraction)
    {
        this.playerInteraction = playerInteraction;

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
        ThirdPersonController thirdPersonController = playerInteraction.GetComponent<ThirdPersonController>();
        StartCoroutine(StartHide());

        IEnumerator StartHide()
        {
            if (isHiding == false)
            {
                isHiding = true;

                boxCollider.isTrigger = true;
                canvas.SetActive(false);

                thirdPersonController.EnableController(false);
                thirdPersonController.transform.position = transform.position;
            }
            else
            {
                isHiding = false;
                thirdPersonController.transform.position = exitPoint.position;
                thirdPersonController.EnableController(true);

                yield return new WaitForSeconds(0.5f);

                boxCollider.isTrigger = false;
                Event();
            }
        }
    }
}
