using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChangeGameBack : MonoBehaviour
{
    [SerializeField]
    private List<SkinInfoItem> _skinInfos;

    [SerializeField]
    private UnityEngine.UI.Image _spriteRenderer;

    [Inject] public void Intialize(PlayerData player)
    {
        _spriteRenderer.sprite = _skinInfos[player.CurrentSkin[(int)PlayerSkinType.background]].SkinSprite;
    }

}
