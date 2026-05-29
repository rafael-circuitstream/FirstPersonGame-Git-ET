using UnityEngine;
using System;
public class PlayerInteractorModule : MonoBehaviour
{
    [SerializeField] private Transform interactionRayOrigin;
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask interactableLayers;

    public Action<GameObject> OnNewInteractionFound;

    private GameObject selectedObject;
    private Interactable pickedUpObject;

    void Update()
    {
        Ray ray = new Ray(interactionRayOrigin.position, interactionRayOrigin.forward * interactionRange);

        RaycastHit hitInfo;

        if( Physics.Raycast(ray, out hitInfo, interactionRange, interactableLayers))
        {
            
            if(selectedObject != hitInfo.collider.gameObject)
            {
                selectedObject = hitInfo.collider.gameObject;

                OnNewInteractionFound?.Invoke(selectedObject);
            }


        }
        else
        {

            if(selectedObject != null)
            {
                selectedObject = null;
                OnNewInteractionFound?.Invoke(null);
            }

        }
    }

    public void InteractWith()
    {
        if(selectedObject)
        {
            Interactable interaction = selectedObject.GetComponent<Interactable>();

            interaction.OnStartInteraction.Invoke();

            if(interaction is InteractablePickUp)
            {
                OnNewInteractionFound?.Invoke(null);
                pickedUpObject = interaction;
                pickedUpObject.transform.SetParent(interactionRayOrigin);
            }
        }
    }

    public void StopInteractWith()
    {
        if(pickedUpObject)
        {
            pickedUpObject.transform.SetParent(null);
            pickedUpObject.OnStopInteraction.Invoke();
            pickedUpObject = null;
        }
    }
}
