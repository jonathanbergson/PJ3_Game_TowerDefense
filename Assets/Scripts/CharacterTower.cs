using UnityEngine;

public class CharacterTower : MonoBehaviour
{
    [Header("Tower Settings")]
    [SerializeField] private float range = 5f;
    [SerializeField] private Transform axisTransform;
    [SerializeField] private GameObject shootPrefab;

    [Header("Character Settings")]
    [SerializeField] private Animator animator;

    private string _enemyTag = Constants.ZombieTag;
    private Transform _targetTransform;

    [Header("Attack Settings")]
    [SerializeField] private float fireRate = 1f;
    private float _fireCountdown;
    [SerializeField] private Transform firePoint;

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
            Vector3 rotacaoParaMirar = Quaternion.Lerp(axisTransform.rotation, rotacaoNecessariaParaVirar, Time.deltaTime * 4).eulerAngles;
            axisTransform.rotation = Quaternion.Euler(0f, rotacaoParaMirar.y, 0f);

            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f/fireRate;
            }

            _fireCountdown -= Time.deltaTime;
        }
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.ZombieTag);
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
        GameObject projetilGObject = Instantiate(shootPrefab, firePoint.position, firePoint.rotation);
        Shoot projetil = projetilGObject.GetComponent<Shoot>();

        if (projetil != null)
        {
            projetil.BuscarAlvo(_targetTransform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
