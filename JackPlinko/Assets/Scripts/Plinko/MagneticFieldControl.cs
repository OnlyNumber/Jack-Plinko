using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class MagneticFieldControl : MonoBehaviour
{
    [SerializeField]
    private List<CardInfo> cardInfos;

    [SerializeField]
    private List<MagneticField> magneticFields;

    [SerializeField]
    private Transform _cardsParent;

    [SerializeField]
    private Card _cardPrefab;

    [SerializeField]
    private BallSpawner _ballSpawner;

    private PlayerData _playerData;

    [Inject]
    public void Initialize(PlayerData player)
    {
        _playerData = player;

        _ballSpawner.OnWin += GetRandomCard;

    }

    [ContextMenu("GetRandomCard")]
    public void GetRandomCard()
    {
        float chanceCard = 100 / cardInfos.Count;

        float RandomCard = Random.Range(0, 100);

        

        for (int i = 0; i < cardInfos.Count; i++)
        {
            if(RandomCard >= chanceCard*i && RandomCard <= chanceCard * i + ((chanceCard/ StaticFields.MAX_CARD_LVL) * _playerData.Cards[i]) && _playerData.Cards[i]!= 0)
            {
                Card transfer = Instantiate(_cardPrefab, _cardsParent);

                transfer.Initialize(cardInfos[i], CardSuit.none);

                int index = i;

                transfer.GetComponent<Button>().onClick.AddListener(() => SetFields(index));

                transfer.GetComponent<StopGame>().Intialize(_ballSpawner);

                return;
            }
            
        }


    }

    public void SetFields(int index)
    {
        ResetFields();

        for (int i = 0; i < magneticFields.Count; i++)
        {
            if(cardInfos[index].ActivatedCirles[i])
            magneticFields[i].gameObject.SetActive(true);
        }
    }

    public void ResetFields()
    {
        for (int i = 0; i < magneticFields.Count; i++)
        {
            magneticFields[i].gameObject.SetActive(false);
        }
    }

}
