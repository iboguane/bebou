using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [SerializeField] private GameObject[] hearts;
    [SerializeField] private float invincibilityFrameTime;
    [SerializeField] private float timeBetweenInvincibilityFrames;
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private MenuManager menuManager;
    private int maxHealth = 3;
    [HideInInspector] public int currentHealth;
    private bool invincibility;
    private Cooldowns invincibilityCooldown;
    private Cooldowns invincibilityFrames;

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
        invincibilityCooldown = new Cooldowns(invincibilityFrameTime);
        invincibilityFrames = new Cooldowns(timeBetweenInvincibilityFrames);
    }

    private void Update()
    {
        invincibilityCooldown.DecreaseCD(Time.deltaTime);
        invincibilityFrames.DecreaseCD(Time.deltaTime);
        if (invincibility)
        {
            if (invincibilityCooldown.isFinished)
            {
                EnableInvincibility(false);
            }
            else if (invincibilityFrames.isFinished)
            {
                spriteR.enabled = !spriteR.enabled;
                invincibilityFrames.ResetCD();
            }
        }
    }

    private void EnableInvincibility(bool enable)
    {
        if (enable)
        {
            invincibilityCooldown.ResetCD();
            invincibilityFrames.ResetCD();
        }
        invincibility = enable;
        spriteR.enabled = !enable;
    }

    public void TakeDamage(int damage = 1)
    {
        if (invincibility) return;
        currentHealth -= damage;
        UpdateHealthBar();
        EnableInvincibility(true);
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        menuManager.DeathMenu();
    }

    public void Pause()
    {
        menuManager.PauseMenu();
    }

    private void UpdateHealthBar()
    {
        for (int i = 0; i < maxHealth; i++)
        {
            hearts[i].SetActive(currentHealth > i);
        }
    }
}
