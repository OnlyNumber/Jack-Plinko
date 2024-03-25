using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SkinShop : MonoBehaviour
{
    private PlayerData _player;

    [SerializeField]
    private PlayerSkinType shopType;

    [SerializeField]
    private List<SkinInfoItem> _skinInfos;

    [SerializeField]
    private SkinUI _skinPrefab;

    [SerializeField]
    private List<SkinUI> _skinItems;

    [SerializeField]
    private RectTransform _skinsParent;

    [SerializeField]
    private float spaceBetweenSkins = 50f;

    public System.Action<int> OnSkinChange;

    public PanelControl panel;

    [Inject]
    public void Initialize(PlayerData playerData)
    {
        _player = playerData;

        while (playerData.PlayerSkins[(int)shopType].list.Count < _skinInfos.Count)
        {
            playerData.PlayerSkins[(int)shopType].list.Add(false);
        }

        while (playerData.PlayerSkins[(int)shopType].list.Count > _skinInfos.Count)
        {
            playerData.PlayerSkins[(int)shopType].list.RemoveAt(playerData.PlayerSkins[(int)shopType].list.Count);
        }

        _skinsParent.sizeDelta = new Vector2( playerData.PlayerSkins[(int)shopType].list.Count * (spaceBetweenSkins + _skinPrefab.GetComponent<RectTransform>().sizeDelta.x), _skinsParent.sizeDelta.y);

        for (int i = 0; i < _skinInfos.Count; i++)
        {
            SkinUI transfer = Instantiate(_skinPrefab, _skinsParent);

            _skinItems.Add(transfer);
            
            if (_player.PlayerSkins[(int)shopType].list[i])
            {
                Debug.Log(i);
                _skinItems[i].CostGO.SetActive(false);
                _skinItems[i].LockImage.gameObject.SetActive(false);
            }
            else
            {

            }
            transfer.SkinImage.sprite = _skinInfos[i].SkinSprite;

            transfer.CostText.text = _skinInfos[i].SkinCost.ToString();

            int index = i;

            transfer.BuyButton.onClick.AddListener(() => BuyAndEquip(index, _skinInfos[index].SkinCost));
        }

        if(playerData.CurrentSkin[(int)shopType] <0)
        {
            BuyAndEquip(0, 0);
        }
        else
        {
            BuyAndEquip(playerData.CurrentSkin[(int)shopType], 0);
        }

    }

    public void BuyAndEquip(int index, float cost)
    {
        if (_player.PlayerSkins[(int)shopType].list[index])
        {
            if(_player.CurrentSkin[(int)shopType] >= 0)
            {
                _skinItems[_player.CurrentSkin[(int)shopType]].AcceptImage.gameObject.SetActive(false);
            }

            _player.CurrentSkin[(int)shopType] = index;

            _skinItems[index].CostGO.SetActive(false);
            _skinItems[index].LockImage.gameObject.SetActive(false);
            _skinItems[index].AcceptImage.gameObject.SetActive(true);

            OnSkinChange?.Invoke(index);

            return;
        }

        if (_player.TryChangeValueCoin(-cost))
        {
            _player.PlayerSkins[(int)shopType].list[index] = true;

            BuyAndEquip(index, cost);
        }
        else
        {
            panel.SetPanel(true);
        }

        return;

    }
}
