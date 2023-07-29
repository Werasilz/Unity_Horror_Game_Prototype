using System.Collections;
using UnityEngine;

public class KeyChecker : MonoBehaviour
{
    [Header("Key")]
    [SerializeField] private Item requireKey;
    [SerializeField] private EventAction[] correctEventActions;
    [SerializeField] private EventAction[] wrongEventActions;
    private bool isEventAction;

    public void CheckKey()
    {
        for (int i = 0; i < PlayerInventory.Instance.GetItems.Count; i++)
        {
            if (requireKey.itemName == PlayerInventory.Instance.GetItems[i].itemName)
            {
                if (isEventAction == false && correctEventActions.Length > 0)
                {
                    StartCoroutine(StartEvent(correctEventActions));
                    return;
                }
            }
        }

        if (isEventAction == false && wrongEventActions.Length > 0)
        {
            StartCoroutine(StartEvent(wrongEventActions));
        }
    }

    IEnumerator StartEvent(EventAction[] eventActions)
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
