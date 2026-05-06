using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Vector3 movementDirection;

    [SerializeField] private float lookSensitivity;
    public Vector3 lookRotationDirection;

    private Camera firstPersonCamera;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        firstPersonCamera = GetComponentInChildren<Camera>();
    }


    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.z = Input.GetAxisRaw("Vertical");

        movementDirection = movementDirection.normalized;
        
        Vector3 forwardDirection = characterController.transform.forward * movementDirection.z;
        Vector3 rightDirection = characterController.transform.right * movementDirection.x;

        characterController.Move( (forwardDirection + rightDirection) * Time.deltaTime * moveSpeed);

        lookRotationDirection.y += Input.GetAxisRaw("Mouse X") * Time.deltaTime * lookSensitivity;
        lookRotationDirection.x -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * lookSensitivity;
        
        lookRotationDirection.x = Mathf.Clamp( lookRotationDirection.x , -80, 80);

        firstPersonCamera.transform.localEulerAngles = new Vector3(lookRotationDirection.x, 0, 0);
        characterController.transform.eulerAngles = new Vector3(0, lookRotationDirection.y, 0);
    }
}
