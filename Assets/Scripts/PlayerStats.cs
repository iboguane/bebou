using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [SerializeField] private GameObject[] hearts;
    private int maxHealth = 3;
    private int currentHealth;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogAssertion("There is more than one PlayerStats instance in the scene");
            return;
        }
        Instance = this;
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage = 1)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        //Death Behaviour
    }

    private void UpdateHealthBar()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            hearts[i].SetActive(currentHealth > i);
        }
    }
}
