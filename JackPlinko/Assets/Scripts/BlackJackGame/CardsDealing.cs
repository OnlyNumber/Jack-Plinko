using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CardsDealing : MonoBehaviour
{
    [SerializeField]
    private List<CardInfo> _cardInfos;

    [SerializeField]
    private List<SkinInfoItem> _skinInfos;

    [SerializeField]
    private Card _cardPrefab;

    public Transform transform;

    private List<Card> _poolCards  = new List<Card>();

    private void Awake()
    {
        /*Card transfer;

        for (int i = 0; i < 4; i++)
        {
            foreach (var item in _cardInfos)
            {
                transfer = Instantiate(_cardPrefab);

                transfer.CardImage.sprite = _skinInfos

                transfer.Initialize(item, (CardSuit)i);

                transfer.gameObject.SetActive(false);

                _poolCards.Add(transfer);
            }
        }*/
    }

    [Inject] public void Initialize(PlayerData playerData)
    {
        Card transfer;

        for (int i = 0; i < 4; i++)
        {
            foreach (var item in _cardInfos)
            {
                transfer = Instantiate(_cardPrefab);

                transfer.CardImage.sprite = _skinInfos[playerData.CurrentSkin[(int)PlayerSkinType.card]].SkinSprite;

                transfer.Initialize(item, (CardSuit)i);

                transfer.gameObject.SetActive(false);

                _poolCards.Add(transfer);
            }
        }
    }


    public Card GetRandomCardFromPool()
    {
        int index;

        do
        {
            index = Random.Range(0, _poolCards.Count);
        }
        while (_poolCards[index].gameObject.activeInHierarchy == true);

        _poolCards[index].gameObject.SetActive(true);


        return _poolCards[index];
    }

    public CardInfo GetCardInfo(int index)
    {
        return _cardInfos[index];
    }

}
