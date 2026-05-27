using UnityEngine;
using System;
public class HealthModule : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;

    public Action OnHealthZero;
    public Action<int> OnHealthChanged;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public void IncreaseHealth(int toIncrease)
    {
        currentHealth += toIncrease;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        OnHealthChanged?.Invoke(currentHealth);
    }

    public void DecreaseHealth(int toDecrease)
    {
        if( currentHealth > 0)
        {
            currentHealth -= toDecrease;

            OnHealthChanged?.Invoke(currentHealth);

            if (IsDead())
            {
                OnHealthZero?.Invoke();
            }

        }



    }
}
