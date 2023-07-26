using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerControllerInputAction m_input;

    [Header("Raycast Interact Settings")]
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private float sphereRadius = 0.75f;

    void Start()
    {
        m_input = GetComponent<PlayerControllerInputAction>();
    }

    void Update()
    {
        RaycastInteract();
    }

    private void RaycastInteract()
    {
        // Press Interact Button
        if (m_input.interact)
        {
            // Find all colliders
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, sphereRadius, interactableLayer);
            float closestDistance = Mathf.Infinity;
            Collider closestCollider = null;

            // Find closest collider
            foreach (var hitCollider in hitColliders)
            {
                // Distance between this object and the current collider
                float distance = Vector3.Distance(transform.position, hitCollider.transform.position);

                // Update closest collider
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCollider = hitCollider;
                }
            }

            // Found closet collider
            if (closestCollider != null)
            {
                closestCollider.gameObject.TryGetComponent<Interactable>(out var interactableObject);

                if (interactableObject != null)
                {
                    print("[Interact] " + interactableObject.GetType().Name);
                    interactableObject.Interact(this);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Interactable interactable = other.GetComponent<Interactable>();
            interactable.canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Interactable interactable = other.GetComponent<Interactable>();
            interactable.canvas.SetActive(false);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
#endif
}