using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour
{
    public static SetupManager Instance;

    public Constants.Levels level;
    // public Constants.Dificulties difficulty;

    [Header("Setup HUD")]
    [SerializeField] private Text levelText;

    [Header("Setup points")]
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject targetPoint;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        Constants.LevelSettings levelSelected = level switch
        {
            Constants.Levels.Level01 => Constants.Level01Settings,
            Constants.Levels.Level02 => Constants.Level02Settings,
            Constants.Levels.Level03 => Constants.Level03Settings,
            _ => Constants.Level01Settings
        };

        SetLevelName(levelSelected.Name);
        SetMaxHealth(levelSelected.MaxHealth);
        SetSpawnPosition(levelSelected.SpawnPosition, levelSelected.WaveEasy);
        SetTargetPosition(levelSelected.TargetPosition);
    }

    private void SetLevelName(string levelName)
    {
        if (levelText) levelText.text = levelName;
    }

    private static void SetMaxHealth(int maxHealth)
    {
        HealthManager.Instance.SetMaxHealth(maxHealth);
    }

    private void SetSpawnPosition(Vector3 position, List<Constants.Wave> waveSettings)
    {
        if (!spawnPoint) return;
        spawnPoint.SetActive(true);
        spawnPoint.transform.position = position;

        SpawnPoint spawner = spawnPoint.GetComponent<SpawnPoint>();
        spawner.Enable(waveSettings);
    }

    private void SetTargetPosition(Vector3 position)
    {
        if (!targetPoint) return;
        targetPoint.SetActive(true);
        targetPoint.transform.position = position;
    }
}
