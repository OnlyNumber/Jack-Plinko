using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TutorialControl : MonoBehaviour
{

    [SerializeField]
    private PanelControl _mainTutorialPanel;

    [SerializeField]
    private PanelControl _mainMenuPanel;
    
    [Inject] public void Initialize(PlayerData player)
    {
        if(player.IsFirstLog)
        {
            _mainTutorialPanel.SetPanel(true);

            player.IsFirstLog = false;
        }
        else
        {
            _mainMenuPanel.SetPanel(true);
        }
    }    

}
