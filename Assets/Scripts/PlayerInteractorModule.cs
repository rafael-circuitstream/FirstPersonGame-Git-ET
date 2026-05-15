using UnityEngine;

public class PlayerInteractorModule : MonoBehaviour
{
    [SerializeField] private Transform interactionRayOrigin;
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask interactableLayers;

    private GameObject selectedObject;
    private Interactable pickedUpObject;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(interactionRayOrigin.position, interactionRayOrigin.forward * interactionRange);

        RaycastHit hitInfo;

        if( Physics.Raycast(ray, out hitInfo, interactionRange, interactableLayers))
        {
            Debug.Log("Press RIGHT MOUSE CLICK to interact");
            selectedObject = hitInfo.collider.gameObject; //here i have an object selected
        }
        else
        {
            selectedObject = null; //here i don't have an object selected
            //nothing is able to press F on
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
