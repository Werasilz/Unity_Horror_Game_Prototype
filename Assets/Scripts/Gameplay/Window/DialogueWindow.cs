using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueWindow : SceneSingleton<DialogueWindow>
{
    [SerializeField] private GameObject window;
    [SerializeField] private TMP_Text text_Dialogue;
    private bool isDialogue;

    public void EnableWindow(Dialogue dialogue)
    {
        if (isDialogue == false)
        {
            StartCoroutine(ActivateDialogue());
        }

        IEnumerator ActivateDialogue()
        {
            isDialogue = true;
            window.SetActive(true);

            for (int i = 0; i < dialogue.dialogueSets.Length; i++)
            {
                text_Dialogue.text = dialogue.dialogueSets[i].dialogue;
                yield return new WaitForSeconds(dialogue.dialogueSets[i].delay);
            }

            text_Dialogue.text = "";
            window.SetActive(false);
            isDialogue = false;
        }
    }
}
