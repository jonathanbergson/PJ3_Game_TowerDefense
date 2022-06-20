using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float velocidade = 70f;

    private void Awake()
    {
        gameObject.tag = Constants.ShootTag;
    }

    public void BuscarAlvo(Transform umTarget)
    {
        target = umTarget;
    }

    private void Update()
    {
        if (target)
        {
            Vector3 direcao = new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z);
            float distanciaNesteFrame = velocidade * Time.deltaTime;

            transform.Translate(direcao.normalized * distanciaNesteFrame, Space.World);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.ZombieTag))
        {
            Destroy(gameObject);
        }
    }
}
