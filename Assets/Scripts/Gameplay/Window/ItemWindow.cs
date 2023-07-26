using TMPro;
using UnityEngine;

public class ItemWindow : SceneSingleton<ItemWindow>
{
    [SerializeField] private GameObject window;
    [SerializeField] private TMP_Text text_Header;
    [SerializeField] private Transform spawnPoint;
    public bool IsOpenWindow { get; private set; }
    private GameObject currentItemObject;

    public void EnableWindow(Item item)
    {
        Time.timeScale = 0;
        IsOpenWindow = true;
        window.SetActive(true);

        // Update information
        text_Header.text = item.itemName;

        // Spawn item
        currentItemObject = Instantiate(item.itemPrefab, spawnPoint);
    }

    public void DisableWindow()
    {
        if (IsOpenWindow)
        {
            IsOpenWindow = false;
            Time.timeScale = 1;
            window.SetActive(false);

            // Clear information
            text_Header.text = "";

            // Destroy item
            Destroy(currentItemObject);
        }
    }
}
