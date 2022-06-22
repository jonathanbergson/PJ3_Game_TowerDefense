using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoserModal : MonoBehaviour
{
    private Button _buttonMenu;
    private const string ButtonMenuName = "Content/ButtonMenu";

    private Button _buttonRestart;
    private const string ButtonRestartName = "Content/ButtonRestart";

    private void Start()
    {
        Constants.Scenes sceneToRestart = SetupManager.Instance.level switch
        {
            Constants.Levels.Level01 => Constants.Scenes.Level01,
            Constants.Levels.Level02 => Constants.Scenes.Level02,
            Constants.Levels.Level03 => Constants.Scenes.Level03,
            _ => Constants.Scenes.Level01
        };

        _buttonMenu = transform.Find(ButtonMenuName).GetComponent<Button>();
        if (_buttonMenu) _buttonMenu.onClick.AddListener(delegate { GoToScene(Constants.Scenes.Main); });

        _buttonRestart = transform.Find(ButtonRestartName).GetComponent<Button>();
        if (_buttonRestart) _buttonRestart.onClick.AddListener(delegate { GoToScene(sceneToRestart); });
    }

    private static void GoToScene(Constants.Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
