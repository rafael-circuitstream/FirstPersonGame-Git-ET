using UnityEngine;

public class CustomPhysicsModule : MonoBehaviour
{
    [SerializeField] private float gravityForce = -9.8f;
    [SerializeField] private LayerMask walkableLayerMask;
    [SerializeField] private float floorCheckRadius;
    public Vector3 upDownForce;

    void Start()
    {
        
    }

    void Update()
    {
        
        if( Physics.CheckSphere(transform.position, floorCheckRadius, walkableLayerMask) )
        {
            upDownForce.y = 0;
        }
        else
        {
            if(upDownForce.y > -10)
            {
                upDownForce.y += gravityForce * Time.deltaTime;
            }
            
        }
        
    }

    public void AddForceUpward(float force)
    {
        if(Physics.CheckSphere(transform.position, floorCheckRadius, walkableLayerMask))
        {
            upDownForce.y = force;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, floorCheckRadius);
    }
}
