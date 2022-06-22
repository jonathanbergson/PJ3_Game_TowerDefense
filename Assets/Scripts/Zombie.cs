using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    [Header("Health")]
    private const int MaxHealth = 6;
    [SerializeField] private int health;
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        health = MaxHealth;
        gameObject.tag = Constants.Tags.Zombie;
    }

    private void Start()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(Constants.Tags.LevelTarget);
        if (targets[0])
        {
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.destination = targets[0].transform.position;
        }
    }

    private void TakeDamage(int damage = 1)
    {
        health -= damage;
        if (healthBar)
        {
            float healthPercent = health / (float) MaxHealth;
            healthBar.fillAmount = Mathf.Clamp(healthPercent, 0f, 1f);
        }

        if (health <= 0)
        {
            BuildManager.instance.MetralhadoraIncrementReward();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case Constants.Tags.Shoot:
                TakeDamage();
                break;
            case Constants.Tags.LevelTarget:
                Destroy(gameObject);
                break;
        }
    }
}
