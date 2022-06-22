using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoint : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private GameObject enemie;

    [Header("Wave Settings")]
    [SerializeField] private Text waveText;
    private int _waveIndex;
    private float _waveCountdown;
    private List<Constants.Wave> _wavesSettings;
    public bool hasWaveToSpawn;

    private void Start()
    {
        gameObject.tag = Constants.Tags.LevelSpawn;
    }

    private void Update()
    {
        _waveCountdown -= Time.deltaTime;
        if (hasWaveToSpawn) SpawnEnemies();

        if (waveText && _waveCountdown >= 0)
            waveText.text = System.Math.Round(_waveCountdown, 1) + "s";
    }

    public void Enable(List<Constants.Wave> waveSettings)
    {
        _waveIndex = 0;
        _wavesSettings = waveSettings;

        SetWaveCountdown();
        hasWaveToSpawn = true;
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
