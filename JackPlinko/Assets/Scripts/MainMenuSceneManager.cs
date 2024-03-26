using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuSceneManager : MonoBehaviour
{
    [SerializeField]
    private PanelControl loadPanel;

    public void LoadPlinko()
    {
        SceneLoad(StaticFields.PLINKO_SCENE);
    }

    public void LoadBJ()
    {
        SceneLoad(StaticFields.BJ_SCENE);
    }

    public void LoadMainMenu()
    {
        SceneLoad(StaticFields.MAIN_MENU_SCENE);
    }

    public void SceneLoad(string scene)
    {

        SceneManager.LoadScene(scene);


    }

    public void Quit()
    {
        Application.Quit();
    }

}
