using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OnClickLevel01Button()
    {
        SceneManager.LoadScene("Level01");
    }

    public void OnClickLevel02Button()
    {
        SceneManager.LoadScene("Level02");
    }

    public void OnclickLevel03Button()
    {
        SceneManager.LoadScene("Level03");
    }
}
