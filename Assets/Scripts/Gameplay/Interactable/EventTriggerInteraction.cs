using System.Collections;
using UnityEngine;

public class EventTriggerInteraction : MonoBehaviour
{
    private InteractionType interactionType = InteractionType.Event;

    [Header("Event")]
    [SerializeField] private EventAction[] eventActions;
    private bool isEventAction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Event();
        }
    }

    private void Event()
    {
        if (isEventAction == false && eventActions.Length > 0)
        {
            StartCoroutine(StartEvent());
        }

        IEnumerator StartEvent()
        {
            isEventAction = true;

            // Call all events
            for (int i = 0; i < eventActions.Length; i++)
            {
                yield return new WaitForSeconds(eventActions[i].delay);
                eventActions[i].action?.Invoke();
            }

            isEventAction = false;
        }
    }
}
