using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackgroundControl : MonoBehaviour
{
    [SerializeField]
    private List<SkinInfoItem> _skinInfos;

    [SerializeField]
    private SkinShop _shop;

    [SerializeField]
    private Image _background;

    private void Start()
    {
        _shop.OnSkinChange += ChangeCardImage;
    }


    public void ChangeCardImage(int index)
    {

        _background.sprite = _skinInfos[index].SkinSprite;

    }
}
