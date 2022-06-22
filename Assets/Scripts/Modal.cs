using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Modal : MonoBehaviour
{
    private const string ButtonMenuName = "Content/ButtonMenu";
    private const string ButtonRestartName = "Content/ButtonRestart";
    private const string ButtonNextLevelName = "Content/ButtonNextLevel";

    private void Start()
    {
        Constants.Scenes sceneToRestart = SetupManager.Instance.level switch
        {
            Constants.Levels.Level01 => Constants.Scenes.Level01,
            Constants.Levels.Level02 => Constants.Scenes.Level02,
            Constants.Levels.Level03 => Constants.Scenes.Level03,
            _ => Constants.Scenes.Level01
        };

        Constants.Scenes sceneToNextLevel = SetupManager.Instance.level switch
        {
            Constants.Levels.Level01 => Constants.Scenes.Level02,
            Constants.Levels.Level02 => Constants.Scenes.Level03,
            Constants.Levels.Level03 => Constants.Scenes.Level01,
            _ => Constants.Scenes.Level02
        };

        Transform buttonMenu = transform.Find(ButtonMenuName);
        if (buttonMenu) buttonMenu.GetComponent<Button>().onClick.AddListener(delegate { GoToScene(Constants.Scenes.Main); });

        Transform buttonRestart = transform.Find(ButtonRestartName);
        if (buttonRestart) buttonRestart.GetComponent<Button>().onClick.AddListener(delegate { GoToScene(sceneToRestart); });

        Transform buttonNextLevel = transform.Find(ButtonNextLevelName);
        if (buttonNextLevel) buttonNextLevel.GetComponent<Button>().onClick.AddListener(delegate { GoToScene(sceneToNextLevel); });
    }

    private static void GoToScene(Constants.Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
