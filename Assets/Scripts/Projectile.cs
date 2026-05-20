using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectilePooling poolParent;

    [SerializeField] private float projectileSpeed;
    
    private Rigidbody projectileRigidbody;

    private void Awake()
    {
        projectileRigidbody = GetComponent<Rigidbody>();
    }

    public void StartBullet()
    {
        Invoke("ResetBullet", 10f);
        projectileRigidbody.linearVelocity = transform.forward * projectileSpeed;
    }

    void ResetBullet()
    {
        projectileRigidbody.linearVelocity = Vector3.zero;
        projectileRigidbody.angularVelocity = Vector3.zero;
        CancelInvoke();
        poolParent.SendBackToAvailable(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ResetBullet();
    }
}
