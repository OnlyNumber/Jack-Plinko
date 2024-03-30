using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
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
        loadPanel.SetPanel(true);


        StartCoroutine(LoadAsync(scene));

        //SceneManager.LoadScene(scene);
    }

    IEnumerator LoadAsync(string scene)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(scene);

        loadAsync.allowSceneActivation = false;

        while(!loadAsync.isDone)
        {

            if(loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(1);
                loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }


    public void Quit()
    {
        Application.Quit();
    }

}
