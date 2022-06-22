using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoint : MonoBehaviour
{
    public static SpawnPoint Instance;

    [Header("Enemies")]
    [SerializeField] private GameObject enemie;
    [SerializeField] private int enemiesTotal;
    [SerializeField] private int enemiesKilled;

    [Header("Wave Settings")]
    [SerializeField] private Text waveText;
    private int _waveIndex;
    private float _waveCountdown;
    private List<Constants.Wave> _wavesSettings;
    public bool hasWaveToSpawn;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        gameObject.tag = Constants.Tags.LevelSpawn;
        enemiesTotal = CountEnemiesTotal();
    }



    private void Update()
    {
        _waveCountdown -= Time.deltaTime;
        if (hasWaveToSpawn) SpawnEnemies();

        if (waveText && _waveCountdown >= 0)
            waveText.text = System.Math.Round(_waveCountdown, 1) + "s";
    }

    private int CountEnemiesTotal()
    {
        return _wavesSettings.Sum(wave => wave.ZombieCount);
    }

    public void Enable(List<Constants.Wave> waveSettings)
    {
        _waveIndex = 0;
        _wavesSettings = waveSettings;

        SetWaveCountdown();
        hasWaveToSpawn = true;
    }

    public void KillEnemie()
    {
        enemiesKilled++;

        if (enemiesKilled >= enemiesTotal)
        {
            ModalManager.Instance.ShowModal(ModalManager.ModalType.Winner);
        }
    }

    private void SpawnEnemies()
    {
        if (_waveCountdown > 0 || _waveIndex >= _wavesSettings.Count) return;

        int zombieCount = _wavesSettings[_waveIndex].ZombieCount;
        for (int i = 0; i < zombieCount; i++)
            Instantiate(enemie, transform.position, transform.rotation);

        _waveIndex++;
        SetWaveCountdown();
    }

    private void SetWaveCountdown()
    {
        if (_waveIndex < _wavesSettings.Count)
            _waveCountdown = _wavesSettings[_waveIndex].DelayTimeToSpawn;
        else
            hasWaveToSpawn = false;
    }
}
