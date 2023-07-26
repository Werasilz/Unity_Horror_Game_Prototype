using System.Collections;
using UnityEngine;

public class HideInteraction : Interactable
{
    private InteractionType interactionType = InteractionType.Hide;
    [SerializeField] private Collider boxCollider;
    [SerializeField] private Transform exitPoint;
    private PlayerInteraction playerInteraction;
    private bool isHiding;

    public override void Interact(PlayerInteraction playerInteraction)
    {
        this.playerInteraction = playerInteraction;

        switch (interactionType)
        {
            case InteractionType.Event:
                Event();
                break;
            case InteractionType.Collectable:
                Collectable();
                break;
            case InteractionType.Note:
                Note();
                break;
            case InteractionType.Hide:
                Hide();
                break;
        }
    }

    public override void Collectable()
    {
    }

    public override void Event()
    {
    }

    public override void Note()
    {
    }

    public override void Hide()
    {
        ThirdPersonController thirdPersonController = playerInteraction.GetComponent<ThirdPersonController>();
        StartCoroutine(StartHide());

        IEnumerator StartHide()
        {
            if (isHiding == false)
            {
                isHiding = true;

                boxCollider.isTrigger = true;
                canvas.SetActive(false);

                thirdPersonController.EnableController(false);
                thirdPersonController.transform.position = transform.position;
            }
            else
            {
                isHiding = false;
                thirdPersonController.transform.position = exitPoint.position;
                thirdPersonController.EnableController(true);

                yield return new WaitForSeconds(0.5f);

                boxCollider.isTrigger = false;
            }
        }
    }
}
