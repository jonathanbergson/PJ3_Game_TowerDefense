using UnityEngine;

public class ZombieHealthBar : MonoBehaviour
{
    private void Update()
    {
        if (Camera.main != null)
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back, Camera.main.transform.rotation * Vector3.up);
        }
    }
}
