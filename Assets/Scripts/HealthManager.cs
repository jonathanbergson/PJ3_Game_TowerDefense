using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    [Header("Health")]
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private Image healthBar;

    [Header("Post Processing")]
    [SerializeField] private Volume volume;
    [SerializeField] private Material material;
    [SerializeField] private bool isPostProcessingEnabled = true;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TogglePostProcessing();
        }
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

    private void TogglePostProcessing()
    {
        isPostProcessingEnabled = !isPostProcessingEnabled;

        if (volume)
        {
            volume.enabled = isPostProcessingEnabled;
        }

        ClearBloodOnScreen();
        SetBloodOnScreen();
    }

    private void ClearBloodOnScreen()
    {
        if (material == null) return;

        material.SetFloat("_edge", 0f);
        material.SetFloat("_noise", 0f);
        material.SetInt("_lvl1", 0);
        material.SetInt("_lvl2", 0);
        material.SetInt("_lvl3", 0);
    }

    private void SetBloodOnScreen()
    {
        if (material == null || isPostProcessingEnabled == false) return;

        if (health <= 8) material.SetInt("_lvl1", 1);
        if (health <= 6) material.SetInt("_lvl2", 1);
        if (health <= 4) material.SetInt("_lvl3", 1);

        float edge = (maxHealth - health) / (float) maxHealth + 0.1f;
        material.SetFloat("_edge", edge);
        material.SetFloat("_noise", 700f);
    }
}
