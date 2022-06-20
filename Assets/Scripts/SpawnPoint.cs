using UnityEngine;
using UnityEngine.UI;

public class SpawnPoint : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private GameObject enemie;

    [Header("Wave Settings")]
    [SerializeField] private Text waveText;
    private float _waveCountdown;
    private int _waveIndex = 0;


    private void Awake()
    {
        gameObject.tag = Constants.Tags.LevelSpawn;
        _waveCountdown = Constants.Level01WaveEasy[0].Item2;
    }

    private void Update()
    {
        _waveCountdown -= Time.deltaTime;
        if (_waveCountdown <= 0f)
        {
            SpawnEnemies();
        }

        if (waveText)
        {
            waveText.text = System.Math.Round(_waveCountdown, 1) + "s";
        }
    }

    private void SpawnEnemies()
    {
        if (_waveIndex < Constants.Level01WaveEasy.Length)
        {
            int enemiesToSpawn = Constants.Level01WaveEasy[_waveIndex].Item1;
            InstantiateEnemies(enemiesToSpawn);

            _waveIndex++;
            _waveCountdown = Constants.Level01WaveEasy[_waveIndex].Item2;
        }
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
