using UnityEngine;

public class InteractablePickUp : Interactable
{
    [SerializeField] private Rigidbody rigidbodyComponent;

    public void FreezeRigidbody()
    {
        rigidbodyComponent.useGravity = false;
        rigidbodyComponent.isKinematic = true;
    }

    public void UnfreezeRigidbody()
    {
        rigidbodyComponent.useGravity = true;
        rigidbodyComponent.isKinematic = false;
    }
}
