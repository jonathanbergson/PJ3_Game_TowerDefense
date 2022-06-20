using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoserModal : MonoBehaviour
{
    private Button _buttonMenu;
    private const string ButtonMenuName = "Content/ButtonMenu";

    private Button _buttonRestart;
    private const string ButtonRestartName = "Content/ButtonRestart";
    [SerializeField] private Constants.Scenes sceneToRestart = Constants.Scenes.Level01;

    private void Start()
    {
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
