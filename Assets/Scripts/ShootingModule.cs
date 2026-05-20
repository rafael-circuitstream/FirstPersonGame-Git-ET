using UnityEngine;

public class ShootingModule : MonoBehaviour
{
    [SerializeField] private ProjectilePooling projectilePool;
    [SerializeField] private Transform weaponTip;


    public void Shoot()
    {
        Projectile pooledProjectile = projectilePool.RetrieveFromAvailableList();
        pooledProjectile.transform.position = weaponTip.position;
        pooledProjectile.transform.rotation = weaponTip.rotation;
        pooledProjectile.gameObject.SetActive(true);
        pooledProjectile.StartBullet();
    }
}
