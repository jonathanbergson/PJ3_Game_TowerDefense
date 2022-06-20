using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    private void Awake()
    {
        gameObject.tag = Constants.Tags.LevelTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.Tags.Zombie))
        {
            // TODO: Spawn many zombies
            // TODO: Destroy all characters
            HealthManager.Instance.TakeDamage();
        }
    }
}
