using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooling : MonoBehaviour
{
    [SerializeField] private int poolAmount;
    [SerializeField] private Projectile prefabToPool;
    [SerializeField] private List<Projectile> availableProjectiles;
    [SerializeField] private List<Projectile> usedProjectiles;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        while(availableProjectiles.Count < poolAmount)
        {
            Projectile projectileClone = Instantiate(prefabToPool);
            
            projectileClone.transform.SetParent(transform);

            projectileClone.gameObject.SetActive(false);
            projectileClone.poolParent = this;

            availableProjectiles.Add(projectileClone);

        }
    }


    public Projectile RetrieveFromAvailableList()
    {
        if(availableProjectiles.Count == 0)
        {
            return null;
        }

        Projectile toRetrieve = availableProjectiles[0];
        availableProjectiles.RemoveAt(0);
        usedProjectiles.Add(toRetrieve);
        return toRetrieve;
    }


    public void SendBackToAvailable(Projectile toReset)
    {
        if (usedProjectiles.Contains(toReset))
        {
            usedProjectiles.Remove(toReset);
            availableProjectiles.Add(toReset);
            toReset.gameObject.SetActive(false);
        }
    }
}
