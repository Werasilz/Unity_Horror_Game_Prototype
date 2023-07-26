using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject canvas;
    public abstract void Interact(PlayerInteraction playerInteraction);
    public abstract void Event();
    public abstract void Collectable();
    public abstract void Note();
    public abstract void Hide();
}

public enum InteractionType
{
    Event,
    Collectable,
    Note,
    Hide,
}