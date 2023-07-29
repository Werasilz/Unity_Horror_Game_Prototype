using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class PuzzleNumberWindow : SceneSingleton<PuzzleNumberWindow>
{
    [SerializeField] private GameObject window;
    [SerializeField] private TMP_Text text_Numbers;
    private int[] required_Numbers;
    private List<int> clicked_Numbers;

    public delegate void OnWrongNumber();
    public event OnWrongNumber OnWrongNumberEvent;
    public delegate void OnCorrectNumber();
    public event OnCorrectNumber OnCorrectNumberEvent;

    public void EnableWindow(int[] numbers)
    {
        required_Numbers = numbers;
        clicked_Numbers = new();
        window.SetActive(true);
        PlayerControllerInputAction.Instance.HideCursor(false);
    }

    public void DisableWindow()
    {
        required_Numbers = null;
        clicked_Numbers = new();
        window.SetActive(false);
        text_Numbers.text = "";
        PlayerControllerInputAction.Instance.HideCursor(true);
    }

    public void ClickNumber(int number)
    {
        if (clicked_Numbers.Count < required_Numbers.Length)
        {
            clicked_Numbers.Add(number);

            StringBuilder numberText = new();

            foreach (int num in clicked_Numbers)
            {
                numberText.Append(num);
            }

            text_Numbers.text = numberText.ToString();
        }
    }

    public void ClickEnter()
    {
        if (clicked_Numbers.Count == required_Numbers.Length)
        {
            for (int i = 0; i < clicked_Numbers.Count; i++)
            {
                if (clicked_Numbers[i] != required_Numbers[i])
                {
                    // Wrong
                    if (OnWrongNumberEvent != null)
                    {
                        OnWrongNumberEvent();
                    }
                    return;
                }
            }

            // Correct
            if (OnCorrectNumberEvent != null)
            {
                OnCorrectNumberEvent();
            }
            return;
        }
    }

    private void OnDestroy()
    {
        OnWrongNumberEvent = null;
        OnCorrectNumberEvent = null;
    }
}
