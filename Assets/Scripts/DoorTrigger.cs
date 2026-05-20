using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;


    private void OnTriggerEnter(Collider other)
    {
        ForceOpenDoor();
        
    }

    private void OnTriggerExit(Collider other)
    {
        ForceCloseDoor();
    }


    public void ForceOpenDoor()
    {
        doorAnimator.SetBool("IsOpen", true);
    }

    public void ForceCloseDoor()
    {
        doorAnimator.SetBool("IsOpen", false);
    }

}
