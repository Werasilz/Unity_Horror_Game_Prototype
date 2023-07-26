using TMPro;
using UnityEngine;

public class NoteWindow : SceneSingleton<NoteWindow>
{
    [SerializeField] private GameObject window;
    [SerializeField] private TMP_Text text_Header;
    [SerializeField] private TMP_Text text_Description;
    public bool IsOpenNote { get; private set; }

    public void EnableWindow(string header, string description)
    {
        Time.timeScale = 0;
        IsOpenNote = true;
        window.SetActive(true);

        // Update information
        text_Header.text = header;
        text_Description.text = description;
    }

    public void DisableWindow()
    {
        if (IsOpenNote)
        {
            IsOpenNote = false;
            Time.timeScale = 1;
            window.SetActive(false);

            // Clear information
            text_Header.text = "";
            text_Description.text = "";
        }
    }
}
