using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameObject healthPrefab;
    [SerializeField] private Transform parentLocation;
    private int currentHealth;

    public void SetHealthBar(int health)
    {
        currentHealth = health;
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        foreach (Transform child in parentLocation.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        if(currentHealth > 0)
        {
            for (int i = 0; i < currentHealth; i++)
            {
                Instantiate(healthPrefab, parentLocation);
            }
        }
    }

    public void RemoveHealth()
    {
        --currentHealth;
        UpdateHealthUI();
    }
}
