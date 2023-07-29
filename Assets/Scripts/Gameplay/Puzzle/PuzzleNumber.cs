using System.Collections;
using UnityEngine;

public class PuzzleNumber : MonoBehaviour
{
    [SerializeField] private int[] requiredNumbers;
    [SerializeField] private EventAction[] correctEventActions;
    [SerializeField] private EventAction[] wrongEventActions;
    private bool isEventAction;

    public void EnableWindow()
    {
        Time.timeScale = 0;
        PuzzleNumberWindow.Instance.EnableWindow(requiredNumbers);
        PuzzleNumberWindow.Instance.OnCorrectNumberEvent += OnCorrectNumber;
        PuzzleNumberWindow.Instance.OnWrongNumberEvent += OnWrongNumber;
    }

    public void DisableWindow()
    {
        PuzzleNumberWindow.Instance.DisableWindow();
        PuzzleNumberWindow.Instance.OnCorrectNumberEvent -= OnCorrectNumber;
        PuzzleNumberWindow.Instance.OnWrongNumberEvent -= OnWrongNumber;
    }

    private void OnCorrectNumber()
    {
        Time.timeScale = 1;
        StartCoroutine(StartEvent(correctEventActions));
    }

    private void OnWrongNumber()
    {
        Time.timeScale = 1;
        StartCoroutine(StartEvent(wrongEventActions));
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
