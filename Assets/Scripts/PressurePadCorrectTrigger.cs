using UnityEngine;

public class PressurePadCorrectTrigger : PressurePadTrigger
{
    [SerializeField] private Rigidbody correctRigidbody;

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody == correctRigidbody)
        {
            base.OnTriggerEnter(other);
        }
        
    }

    protected override void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody == correctRigidbody)
        {
            base.OnTriggerExit(other);
        }   
    }
}
