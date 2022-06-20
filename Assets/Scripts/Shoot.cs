using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float speed = 70f;
    private Transform _target;

    private void Awake()
    {
        gameObject.tag = Constants.Tags.Shoot;
    }

    private void Update()
    {
        if (_target)
        {
            Vector3 direction = _target.position - transform.position;
            direction.y = 0;
            Vector3 translation = direction.normalized * (speed * Time.deltaTime);
            transform.Translate(translation, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.Tags.Zombie))
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform zombieTarget)
    {
        _target = zombieTarget;
    }
}
