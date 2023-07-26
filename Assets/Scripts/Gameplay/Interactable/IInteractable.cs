using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject canvas;
    public abstract void Interact(PlayerInteraction playerInteraction);
}
