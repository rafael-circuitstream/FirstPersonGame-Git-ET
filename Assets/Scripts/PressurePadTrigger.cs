using UnityEngine;
using UnityEngine.Events;

public class PressurePadTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody correctRigidbody;
    [SerializeField] private bool bypassCorrectRigidbody;

    public UnityEvent OnPressureActivate;
    public UnityEvent OnPressureDeactive;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (bypassCorrectRigidbody || other.attachedRigidbody == correctRigidbody)
        {
            OnPressureActivate.Invoke();
        }

    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (bypassCorrectRigidbody || other.attachedRigidbody == correctRigidbody)
        {
            Debug.Log("Trigger is deactivating");

            OnPressureDeactive.Invoke();
        }

    }

}
