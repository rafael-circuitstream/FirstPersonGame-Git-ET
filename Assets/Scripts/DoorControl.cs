using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private GameObject triggerGameObject;
    [SerializeField] private MeshRenderer doorRenderer;
    [SerializeField] private bool unlocked;

    private void Start()
    {
        if(unlocked)
        {
            UnlockDoor();
        }
        else
        {
            LockDoor();
        }
    }

    public void UnlockDoor()
    {
        unlocked = true;
        triggerGameObject.SetActive(true);
        doorRenderer.material.color = Color.blue;
    }

    public void LockDoor()
    {
        unlocked = false;
        triggerGameObject.SetActive(false);
        doorRenderer.material.color = Color.red;
    }
}
