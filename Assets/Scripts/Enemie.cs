using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemie : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent _navMeshAgent;

    private const int MaxHealth = 4;
    [SerializeField] private int health;
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        gameObject.tag = Constants.ZombieTag;
    }

    private void Start()
    {
        health = MaxHealth;
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target)
        {
            _navMeshAgent.destination = target.position;
        }
        else
        {
            _navMeshAgent.ResetPath();
        }
    }

    private void Damage()
    {
        health -= 1;

        if (health <= 0)
        {
            BuildManager.instance.MetralhadoraIncrementReward();
            Destroy(gameObject);
        }

        if (healthBar)
        {
            float healthPercent = health / (float) MaxHealth;
            healthBar.fillAmount = Mathf.Clamp(healthPercent, 0f, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case Constants.ShootTag:
                Damage();
                break;
            case Constants.LevelTargetTag:
                Destroy(gameObject);
                break;
        }
    }
}
