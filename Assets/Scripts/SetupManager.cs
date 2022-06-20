using UnityEngine;
using UnityEngine.UI;

public class SetupManager : Manager
{
    public Constants.Levels level;
    public Constants.Dificulties difficulty;

    [Header("Setup HUD")]
    [SerializeField] private Text levelText;

    [Header("Setup points")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform targetPoint;

    public LevelSettings Level01Settings = new LevelSettings
    {
        name = "Level 01",
        maxHealth = 100,
        spawnPosition = new Vector3(-18,1,-26),
        targetPosition = new Vector3(-40,1,10),
    };

    public LevelSettings Level02Settings = new LevelSettings
    {
        name = "Level 02",
        maxHealth = 12,
        spawnPosition = new Vector3(-10, 1, -4),
        targetPosition = new Vector3(-10,1,10),
    };

    public LevelSettings Level03Settings = new LevelSettings
    {
        name = "Level 02",
        maxHealth = 12,
        spawnPosition = new Vector3(-10, 1, -4),
        targetPosition = new Vector3(0, 0, 0),
    };

    private void Start()
    {
        LevelSettings levelSelected = level switch
        {
            Constants.Levels.Level01 => Level01Settings,
            Constants.Levels.Level02 => Level02Settings,
            Constants.Levels.Level03 => Level03Settings,
            _ => Level01Settings
        };

        SetLevelName(levelSelected.name);
        SetMaxHealth(levelSelected.maxHealth);
        SetSpawnPosition(levelSelected.spawnPosition);
        SetTargetPosition(levelSelected.targetPosition);
    }

    private void SetLevelName(string levelName)
    {
        if (levelText) levelText.text = levelName;
    }

    private void SetMaxHealth(int maxHealth)
    {
        HealthManager.Instance.SetMaxHealth(maxHealth);
    }

    private void SetSpawnPosition(Vector3 position)
    {
        if (spawnPoint) spawnPoint.position = position;
    }

    private void SetTargetPosition(Vector3 position)
    {
        if (targetPoint) targetPoint.position = position;
    }
}
