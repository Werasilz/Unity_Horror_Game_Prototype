using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationWindow : SceneSingleton<NotificationWindow>
{
    [SerializeField] private GameObject window;
    [SerializeField] private TMP_Text text_Notification;

    public void EnableWindow(string notification)
    {
        StartCoroutine(ActivateDialogue());

        IEnumerator ActivateDialogue()
        {
            window.SetActive(true);
            text_Notification.text = notification;
            yield return new WaitForSeconds(3f);
            window.SetActive(false);
            text_Notification.text = "";
        }
    }
}
