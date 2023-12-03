using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    [Header("Health")]
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private Image healthBar;

    [SerializeField] private Material mat;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        health = maxHealth;
        ClearBloodOnScreen();
    }

    public void SetMaxHealth(int value)
    {
        health = value;
        maxHealth = value;
        SetBloodOnScreen();
    }

    public void TakeDamage(int damage = 1)
    {
        health -= damage;
        if (healthBar)
        {
            float healthPercent = health / (float) maxHealth;
            healthBar.fillAmount = Mathf.Clamp(healthPercent, 0f, 1f);
            SetBloodOnScreen();
        }

        if (health <= 0)
        {
            ModalManager.Instance.ShowModal(ModalManager.ModalType.Loser);
        }
    }

    private void ClearBloodOnScreen()
    {
        if (mat == null) return;
        if (health <= 8) mat.SetFloat("_Edge", 0f);
        if (health <= 8) mat.SetInt("_lvl1", 0);
        if (health <= 6) mat.SetInt("_lvl2", 0);
        if (health <= 4) mat.SetInt("_lvl3", 0);
    }

    private void SetBloodOnScreen()
    {
        if (mat == null) return;
        if (health <= 8) mat.SetInt("_lvl1", 1);
        if (health <= 6) mat.SetInt("_lvl2", 1);
        if (health <= 4) mat.SetInt("_lvl3", 1);

        float edge = (maxHealth - health) / (float) maxHealth + 0.1f;
        mat.SetFloat("_Edge", edge);
    }
}
