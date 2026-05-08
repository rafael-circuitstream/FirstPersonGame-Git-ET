using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Vector3 movementDirection;

    [SerializeField] private float lookSensitivity;
    public Vector3 lookRotationDirection;

    [SerializeField] private float jumpForce;

    private Camera firstPersonCamera;
    private CharacterController characterController;
    private CustomPhysicsModule customPhysicsModule;
    private ShootingModule shootingModule;

    private void Awake()
    {
        firstPersonCamera = GetComponentInChildren<Camera>();

        characterController = GetComponent<CharacterController>();       
        customPhysicsModule = GetComponent<CustomPhysicsModule>();
        shootingModule = GetComponent<ShootingModule>();
    }


    void Update()
    {
        JumpInput();
        MoveInput();
        LookInput();
        ShootInput();
    }

    private void MoveInput()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.z = Input.GetAxisRaw("Vertical");

        movementDirection = movementDirection.normalized;

        Vector3 forwardDirection = characterController.transform.forward * movementDirection.z;
        Vector3 rightDirection = characterController.transform.right * movementDirection.x;
        Vector3 gravityDirection = customPhysicsModule.upDownForce;
        
        Vector3 movementInput = forwardDirection + rightDirection;
        Vector3 totalMovement = (movementInput * moveSpeed) + gravityDirection;

        characterController.Move( totalMovement * Time.deltaTime );
    }   
    
    private void LookInput()
    {

        lookRotationDirection.y += Input.GetAxisRaw("Mouse X") * Time.deltaTime * lookSensitivity;
        lookRotationDirection.x -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * lookSensitivity;

        lookRotationDirection.x = Mathf.Clamp(lookRotationDirection.x, -80, 80);

        firstPersonCamera.transform.localEulerAngles = new Vector3(lookRotationDirection.x, 0, 0);
        characterController.transform.eulerAngles = new Vector3(0, lookRotationDirection.y, 0);
    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            customPhysicsModule.AddForceUpward(jumpForce);
        }
    }

    private void ShootInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shootingModule.Shoot();
        }
    }
}
