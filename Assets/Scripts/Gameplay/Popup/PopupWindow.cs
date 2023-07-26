using TMPro;
using UnityEngine;

public class PopupWindow : SceneSingleton<PopupWindow>
{
    [SerializeField] private GameObject window;
    [SerializeField] private TMP_Text text_PopupName;
    [SerializeField] private TMP_Text text_Description;

    public void EnableWindow(string popupName, string description)
    {
        window.SetActive(true);
        text_PopupName.text = popupName;
        text_Description.text = description;
    }

    public void DisableWindow()
    {
        window.SetActive(false);
        text_PopupName.text = "";
        text_Description.text = "";
    }
}
