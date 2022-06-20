using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.ZombieTag))
        {
            // TODO: Spawn many zombies
            // TODO: Destroy all characters
            HealthManager.Instance.TakeDamage();
        }
    }
}
