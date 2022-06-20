using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    [Header("Health")]
    private const int MaxHealth = 10;
    [SerializeField] private int health;
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        health = MaxHealth;
    }

    public void TakeDamage(int damage = 1)
    {
        health -= damage;
        if (healthBar)
        {
            float healthPercent = health / (float) MaxHealth;
            healthBar.fillAmount = Mathf.Clamp(healthPercent, 0f, 1f);
        }

        if (health <= 0)
        {
            Debug.Log("You Dead!");
            ModalManager.Instance.ShowModal(ModalManager.ModalType.Loser);
        }
    }
}
