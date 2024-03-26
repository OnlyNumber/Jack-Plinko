using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UpgradeCardManager : MonoBehaviour
{
    [SerializeField]
    private List<CardInfo> _cardInfos;

    [SerializeField]
    private UpgradCardItem _cardItemPrefab;

    private List<UpgradCardItem> _cardItemspool = new List<UpgradCardItem>(); 

    [SerializeField]
    private List<SkinInfoItem> _skinInfos;

    [SerializeField]
    private RectTransform _cardItemsPosition;

    [SerializeField]
    private float UpgradeCost;

    private PlayerData playerData;

    [SerializeField]
    private SkinShop _shop;

    [SerializeField]
    private PanelControl _notEnoughPanel;

    private float _spacingAmount = 50;

    private void Start()
    {
        _shop.OnSkinChange += ChangeCardImage;
    }

    [Inject]
    public void Initialize(PlayerData playerData)
    {

        while (playerData.Cards.Count < _cardInfos.Count)
        {
            playerData.Cards.Add(0);
        }

        while (playerData.Cards.Count > _cardInfos.Count)
        {
            playerData.Cards.RemoveAt(playerData.Cards.Count);
        }

        _cardItemsPosition.sizeDelta = new Vector2(_cardItemsPosition.sizeDelta.x, playerData.Cards.Count * (_spacingAmount + _cardItemPrefab.GetComponent<RectTransform>().sizeDelta.y));


        for (int i = 0; i < playerData.Cards.Count; i++)
        {
            int transferIndex;
            
            UpgradCardItem transferItem = Instantiate(_cardItemPrefab, _cardItemsPosition.transform);

            _cardItemspool.Add(transferItem);

            transferItem.MyCard.Initialize(_cardInfos[i], CardSuit.none);

            transferItem.MyUpgradeIndexText.text = playerData.Cards[i].ToString();

            transferIndex = i;

            transferItem.MyUpgradeButton.onClick.AddListener(() => UpgradeCard(playerData, transferIndex, transferItem));

            if (playerData.Cards[transferIndex] != 0)
            {
                transferItem.MyUpgradeButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Upgrade: " + (playerData.Cards[transferIndex] * UpgradeCost);
            }
            else
            {
                transferItem.MyUpgradeButton.interactable = false;

                transferItem.MyUpgradeButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Not available: ";
            }

            if (playerData.Cards[i] == 0 && playerData.Cards[i] > StaticFields.MAX_CARD_LVL)
            {
                transferItem.MyUpgradeButton.interactable = false;
            }
        }

        ChangeCardImage(playerData.CurrentSkin[(int)PlayerSkinType.card]);
    }

    public void UpgradeCard(PlayerData playerData, int index, UpgradCardItem item)
    {
        if (playerData.TryChangeValueCoin(-UpgradeCost * playerData.Cards[index]))
        {
            playerData.Cards[index]++;

            item.MyUpgradeButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Upgrade: " + (playerData.Cards[index] * UpgradeCost);

            item.MyUpgradeIndexText.text = playerData.Cards[index].ToString();
        }
        else
        {
            _notEnoughPanel.SetPanel(true);
        }
    }

    public void ChangeCardImage(int index)
    {
        foreach (var item in _cardItemspool)
        {
            item.MyCard.CardImage.sprite = _skinInfos[index].SkinSprite;
        }
    }



}
