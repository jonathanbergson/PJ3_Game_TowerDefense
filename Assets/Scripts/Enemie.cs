using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemie : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent navMeshAgent;

    [SerializeField] private int live = 2;

    private void Awake()
    {
        gameObject.tag = Constants.EnemyTag;
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target)
        {
            navMeshAgent.destination = target.position;
        }
        else
        {
            navMeshAgent.ResetPath();
        }
    }

    private void Damage()
    {
        live -= 1;

        if (live <= 0)
        {
            BuildManager.instance.MetralhadoraIncrementReward();
            Destroy(gameObject);
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
