using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    private float _speed;

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
            Vector3 translation = direction.normalized * (_speed * Time.deltaTime);
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

    public void Shoot(Transform target, float speed = 60f)
    {
        _target = target;
        _speed = speed;
    }
}
