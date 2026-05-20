using UnityEngine;
using UnityEngine.Events;

public class PressurePadTrigger : MonoBehaviour
{
    public UnityEvent OnPressureActivate;
    public UnityEvent OnPressureDeactive;

    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger is activating");
        OnPressureActivate.Invoke();
    }

    protected virtual void OnTriggerExit(Collider other)
    {

        Debug.Log("Trigger is deactivating");

        OnPressureDeactive.Invoke();
    }

}
