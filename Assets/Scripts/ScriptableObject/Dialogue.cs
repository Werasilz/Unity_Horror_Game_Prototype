using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Data/Dialogue")]
public class Dialogue : ScriptableObject
{
    public int dialogueIndex;
    public DialogueSet[] dialogueSets;

    [Serializable]
    public struct DialogueSet
    {
        public float delay;
        [TextArea(3, 10)]
        public string dialogue;
    }
}
