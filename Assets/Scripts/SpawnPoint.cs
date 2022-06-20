using UnityEngine;
using UnityEngine.UI;

public class SpawnPoint : MonoBehaviour
{
    public GameObject enemie;
    public Transform target;

    [Header("Wave Settings")]
    [SerializeField] private Text waveText;
    [SerializeField] private float countDownWaves;
    [SerializeField] [Range(10f, 1f)] private float timeBetweenWaves = 5f;

    private int[] enemiesWaveRange = { 2, 4, 5, 8 };

    private void Awake()
    {
        gameObject.tag = Constants.Tags.LevelSpawn;
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
                Instantiate(enemie, transform.position, transform.rotation);
            }
        }
    }
}
