using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneManager : MonoBehaviour
{
    public void LoadPlinko()
    {
        SceneManager.LoadScene(StaticFields.PLINKO_SCENE);
    }

    public void LoadBJ()
    {
        SceneManager.LoadScene(StaticFields.BJ_SCENE);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(StaticFields.MAIN_MENU_SCENE);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
