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

    [SerializeField]
    private List<SkinInfoItem> _skinInfos;

    [Inject]
    public void Initialize(PlayerData player)
    {
        _playerData = player;

        _ballSpawner.OnWin += GetRandomCard;
        _ballSpawner.OnWin += ResetFields;
    }

    [ContextMenu("GetRandomCard")]
    public void GetRandomCard()
    {
        float chanceCard = 100 / cardInfos.Count;

        float RandomCard = Random.Range(0, 100);



        //for (int i = 0; i < cardInfos.Count; i++)
        //{
        //if(RandomCard >= chanceCard*i && RandomCard <= chanceCard * i + ((chanceCard/ StaticFields.MAX_CARD_LVL) * _playerData.Cards[i]) && _playerData.Cards[i]!= 0)
        //{
        Card transfer = Instantiate(_cardPrefab, _cardsParent);

        transfer.Initialize(cardInfos[0], CardSuit.none);

        transfer.CardImage.sprite = _skinInfos[_playerData.CurrentSkin[(int)PlayerSkinType.card]].SkinSprite;

        int index = 0;

        transfer.GetComponent<Button>().onClick.AddListener(() => SetFields(index, transfer.gameObject));

        transfer.GetComponent<StopGame>().Intialize(_ballSpawner);

        return;
        //}

        //}


    }

    public void SetFields(int index,GameObject gameObject)
    {
        ResetFields();

        Debug.Log("fields");


        for (int i = 0; i < magneticFields.Count; i++)
        {
            Debug.Log("for");
            if (cardInfos[index].ActivatedCirles[i])
            {
                Debug.Log("fields true");


                magneticFields[i].gameObject.SetActive(true);
            }
        }

        Destroy(gameObject);

    }

    public void ResetFields()
    {
        for (int i = 0; i < magneticFields.Count; i++)
        {
            magneticFields[i].gameObject.SetActive(false);
        }
    }

}
