using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private HealthModule playerHealth;
    
    private void Awake()
    {
        playerHealth.OnHealthZero += ShowGameOver;
        playerHealth.OnHealthChanged += UpdateHealthValue;

    }


    public void UpdateHealthValue(int currentHealth)
    {
        healthText.text = currentHealth.ToString() + "%";
    }

    public void ShowGameOver()
    {
        healthText.text = "YOU ARE DEAD!";
        healthText.color = Color.red;
    }

}
