using UnityEngine;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour
{
    private static SetupManager _instance;

    public Constants.Levels level;
    public Constants.Dificulties difficulty;

    [Header("Setup HUD")]
    [SerializeField] private Text levelText;

    [Header("Setup points")]
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject targetPoint;

    private void Awake()
    {
        if (_instance == null) _instance = this;
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

        SetLevelName(levelSelected.name);
        SetMaxHealth(levelSelected.maxHealth);
        SetSpawnPosition(levelSelected.spawnPosition);
        SetTargetPosition(levelSelected.targetPosition);
    }

    private void SetLevelName(string levelName)
    {
        if (levelText)
        {
            levelText.text = levelName;
        }
    }

    private void SetMaxHealth(int maxHealth)
    {
        HealthManager.Instance.SetMaxHealth(maxHealth);
    }

    private void SetSpawnPosition(Vector3 position)
    {
        if (spawnPoint)
        {
            spawnPoint.SetActive(true);
            spawnPoint.transform.position = position;
        }
    }

    private void SetTargetPosition(Vector3 position)
    {
        if (targetPoint)
        {
            targetPoint.SetActive(true);
            targetPoint.transform.position = position;
        }
    }
}
