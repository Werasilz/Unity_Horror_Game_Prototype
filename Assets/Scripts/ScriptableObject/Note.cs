using UnityEngine;


[CreateAssetMenu(fileName = "Note", menuName = "Data/Note")]
public class Note : ScriptableObject
{
    public string header;

    [TextArea(10, 100)]
    public string description;
}
