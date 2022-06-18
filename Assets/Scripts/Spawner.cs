using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemie;
    public Transform target;

    [Header("Wave Settings")]
    [SerializeField] private Text waveText;
    [SerializeField] private float countDownWaves;
    [SerializeField] [Range(10f, 1f)] private float timeBetweenWaves = 5f;

    private int[] enemiesWaveRange = { 2, 4, 5, 8 };

    private void Start()
    {
        countDownWaves = 2f;
    }

    private void Update()
    {
        if (countDownWaves <= 0f)
        {
            SpawnEnemies();
            countDownWaves = timeBetweenWaves;
        }
        countDownWaves -= Time.deltaTime;

        if (waveText)
        {
            waveText.text = System.Math.Round(countDownWaves, 1) + "s";
        }
    }

    private void SpawnEnemies()
    {
        int index = Random.Range(0, enemiesWaveRange.Length);
        InstantiateEnemies(enemiesWaveRange[index]);
    }

    private void InstantiateEnemies(int count)
    {
        if (enemie)
        {
            for (int i = 0; i < count; i++)
            {
                Enemie enemieInstance = Instantiate(enemie, transform.position, transform.rotation).GetComponent<Enemie>();
                enemieInstance.target = target;
            }
        }
    }
}
