using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    private Transform _target;
    private GameObject[] _targets;
    private NavMeshAgent _navMeshAgent;

    [Header("Health")]
    private const int MaxHealth = 6;
    [SerializeField] private int health;
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        health = MaxHealth;
        gameObject.tag = Constants.Tags.Zombie;

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _targets = GameObject.FindGameObjectsWithTag(Constants.Tags.LevelTarget);
        if (_targets.Length > 0) _target = _targets[0].transform;
    }

    private void Update()
    {
        if (_target)
        {
            _navMeshAgent.destination = _target.position;
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
