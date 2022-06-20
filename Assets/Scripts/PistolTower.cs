using UnityEngine;

public class PistolTower : MonoBehaviour
{
    private Transform _targetTransform;

    [Header("Tower Settings")]
    [SerializeField] private float range = 8f;
    [SerializeField] private GameObject bullet;

    [Header("Attack Settings")]
    [SerializeField] private float fireFrequency = 1f;
    [SerializeField] private Transform firePoint;
    private float _fireCountdown;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (_targetTransform != null)
        {
            Vector3 direcaoParaMirar = _targetTransform.position - transform.position;
            Quaternion rotacaoNecessariaParaVirar = Quaternion.LookRotation(direcaoParaMirar);
            Vector3 rotacaoParaMirar = Quaternion.Lerp(transform.rotation, rotacaoNecessariaParaVirar, Time.deltaTime * 4).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotacaoParaMirar.y, 0f);

            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f/fireFrequency;
            }

            _fireCountdown -= Time.deltaTime;
        }
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.Tags.Zombie);
        GameObject enemiyClose = null;
        float distanceToEnemyClose = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < distanceToEnemyClose)
            {
                distanceToEnemyClose = distanceToEnemy;
                enemiyClose = enemy;
            }
        }

        if (enemiyClose != null && distanceToEnemyClose < range)
        {
            _targetTransform = enemiyClose.transform;
        }
        else
        {
            _targetTransform = null;
        }
    }

    private void Shoot()
    {
        if (bullet)
        {
            Bullet b = Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<Bullet>();
            b.Shoot(_targetTransform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
