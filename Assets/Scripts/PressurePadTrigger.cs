using UnityEngine;
using UnityEngine.Events;

public class PressurePadTrigger : MonoBehaviour
{
    public UnityEvent OnPressureActivate;
    public UnityEvent OnPressureDeactive;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger is activating");

        OnPressureActivate.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger is deactivating");

        OnPressureDeactive.Invoke();
    }

}
