using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    private Rigidbody projectileRigidbody;

    private void Awake()
    {
        projectileRigidbody = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Invoke("ResetBullet", 10f);
        projectileRigidbody.linearVelocity = transform.forward * projectileSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetBullet()
    {
        Destroy(gameObject);
    }
}
