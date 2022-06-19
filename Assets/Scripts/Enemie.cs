using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemie : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent _navMeshAgent;

    private const int TotalHealth = 4;
    [SerializeField] private int health;
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        gameObject.tag = Constants.EnemyTag;
    }

    private void Start()
    {
        health = TotalHealth;
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
            Debug.Log(Mathf.Clamp((float) health / TotalHealth, 0f, 1f));
            healthBar.fillAmount = Mathf.Clamp((float) health / TotalHealth, 0f, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.ShootTag))
        {
            Damage();
            Destroy(other.gameObject);
        }
    }
}
