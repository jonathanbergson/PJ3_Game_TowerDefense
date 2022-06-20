using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    [Header("Health")]
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        health = maxHealth;
    }

    public void SetMaxHealth(int value)
    {
        health = value;
        maxHealth = value;
    }

    public void TakeDamage(int damage = 1)
    {
        health -= damage;
        if (healthBar)
        {
            float healthPercent = health / (float) maxHealth;
            healthBar.fillAmount = Mathf.Clamp(healthPercent, 0f, 1f);
        }

        if (health <= 0)
        {
            Debug.Log("You Dead!");
            ModalManager.Instance.ShowModal(ModalManager.ModalType.Loser);
        }
    }
}
